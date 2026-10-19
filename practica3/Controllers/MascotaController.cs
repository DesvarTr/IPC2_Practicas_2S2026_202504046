using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using practica3.Models;
using practica3.Services;

namespace practica3.Controllers;

public class MascotasController : Controller
{
    private const string ClaveActiva = "MascotaActivaId";
    private readonly MascotaService _service;

    public MascotasController(MascotaService service)
    {
        _service = service;
    }

    // La mascota "activa" vive en la sesión del navegador (sin contraseñas)
    private Mascota? ObtenerActiva()
    {
        int? id = HttpContext.Session.GetInt32(ClaveActiva);
        if (id == null) return null;

        Mascota? mascota = _service.Buscar(id.Value);
        if (mascota == null) HttpContext.Session.Remove(ClaveActiva);   // ya no existe
        return mascota;
    }

    // ===================== ACCESO A INFORMACIÓN =====================

    // GET /Mascotas/Acceso?consultar=3
    [HttpGet]
    public IActionResult Acceso(int? consultar)
    {
        var vm = new AccesoViewModel { Mascotas = _service.Lista };

        if (consultar.HasValue)
        {
            vm.Detalle = _service.Buscar(consultar.Value);
            if (vm.Detalle == null) TempData["Error"] = $"No existe una mascota con el código {consultar}.";
        }
        return View(vm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Registrar(MascotaFormViewModel datos)
    {
        if (!ModelState.IsValid)
            return View("Acceso", new AccesoViewModel { Mascotas = _service.Lista, Form = datos });

        Mascota? nueva = MascotaMapper.Crear(datos);
        if (nueva == null)
        {
            ModelState.AddModelError(nameof(datos.Tipo), "Tipo de mascota no válido.");
            return View("Acceso", new AccesoViewModel { Mascotas = _service.Lista, Form = datos });
        }

        _service.Agregar(nueva);
        TempData["Mensaje"] = $"{nueva.Tipo} \"{nueva.Nombre}\" registrado con el código {nueva.Codigo}.";
        return RedirectToAction(nameof(Acceso));
    }

    // ================== ADMINISTRACIÓN DE INFORMACIÓN ==================

    [HttpGet]
    public IActionResult Administracion()
    {
        Mascota? activa = ObtenerActiva();
        return View(new AdminViewModel
        {
            Mascotas = _service.Lista,
            Activa = activa,
            Form = activa == null ? new MascotaFormViewModel() : MascotaMapper.ADatos(activa)
        });
    }

    // "Inicio de sesión" por selección: código o nombre
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Seleccionar(string? codigo)
    {
        codigo = codigo?.Trim() ?? "";
        Mascota? mascota = int.TryParse(codigo, out int id)
            ? _service.Buscar(id)
            : _service.BuscarPorNombre(codigo);

        if (mascota == null)
            TempData["Error"] = "No se encontró ninguna mascota con ese código o nombre.";
        else
            HttpContext.Session.SetInt32(ClaveActiva, Convert.ToInt32(mascota.Codigo));

        return RedirectToAction(nameof(Administracion));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult QuitarSeleccion()
    {
        HttpContext.Session.Remove(ClaveActiva);
        return RedirectToAction(nameof(Administracion));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Editar(MascotaFormViewModel datos)
    {
        Mascota? activa = ObtenerActiva();
        if (activa == null) return SinMascotaActiva();

        if (!ModelState.IsValid)
            return View("Administracion", new AdminViewModel { Mascotas = _service.Lista, Activa = activa, Form = datos });

        MascotaMapper.Aplicar(activa, datos);
        TempData["Mensaje"] = $"Los datos de \"{activa.Nombre}\" se actualizaron.";
        return RedirectToAction(nameof(Administracion));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Eliminar()
    {
        Mascota? activa = ObtenerActiva();
        if (activa == null) return SinMascotaActiva();

        _service.Eliminar(activa.Codigo);
        HttpContext.Session.Remove(ClaveActiva);
        TempData["Mensaje"] = $"\"{activa.Nombre}\" fue eliminada.";
        return RedirectToAction(nameof(Administracion));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CambiarEstado()
    {
        Mascota? activa = ObtenerActiva();
        if (activa == null) return SinMascotaActiva();

        activa.cambiarEstadoSalud();
        return RedirectToAction(nameof(Administracion));
    }

    // GET /Mascotas/CalcularDosis?dosisPorKg=2.5  -> JSON (lo consume el JavaScript al escribir)
    [HttpGet]
    public IActionResult CalcularDosis(string? dosisPorKg)
    {
        Mascota? activa = ObtenerActiva();
        if (activa == null) return BadRequest(new { error = "No hay una mascota activa." });

        if (!double.TryParse(dosisPorKg, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor)
            || valor < 0)
            return BadRequest(new { error = "Valor no válido." });

        // El cálculo es polimórfico: cada tipo aplica su propio factor
        return Json(new { dosis = activa.calcularDosis(valor) });
    }

    private IActionResult SinMascotaActiva()
    {
        TempData["Error"] = "Seleccione una mascota primero.";
        return RedirectToAction(nameof(Administracion));
    }
}