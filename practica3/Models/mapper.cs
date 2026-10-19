using practica3.Models;

namespace practica3.Services;

// Traduce entre el formulario (ViewModel) y las clases del dominio.
public static class MascotaMapper
{
    public static Mascota? Crear(MascotaFormViewModel vm)
    {
        Mascota? mascota = vm.Tipo switch
        {
            "Perro" => new Perro(),
            "Gato" => new Gato(),
            "Ave" => new Ave(),
            "Tortuga" => new Tortuga(),
            _ => null
        };
        if (mascota != null) Aplicar(mascota, vm);
        return mascota;
    }

    // Copia los datos del formulario a una mascota existente (el tipo no cambia)
    public static void Aplicar(Mascota mascota, MascotaFormViewModel vm)
    {
        mascota.Nombre = vm.Nombre.Trim();
        mascota.Edad = vm.Edad ?? 0;
        mascota.Peso = vm.Peso ?? 0;
        mascota.Sexo = vm.EsHembra;

        switch (mascota)
        {
            case Perro p:
                p.Raza = (vm.Raza ?? "").Trim();
                p.Tamano = vm.Tamano ?? "";
                break;
            case Gato g:
                g.Raza = (vm.Raza ?? "").Trim();
                g.EstaEsterilizado = vm.EstaEsterilizado;
                break;
            case Ave a:
                a.Envergadura = vm.Envergadura ?? 0;
                a.PuedeVolar = vm.PuedeVolar;
                break;
            case Tortuga t:
                t.TipoCaparazon = (vm.TipoCaparazon ?? "").Trim();
                t.EsAcuatica = vm.EsAcuatica;
                break;
        }
    }

    // Llena el formulario de edición con los datos de la mascota activa
    public static MascotaFormViewModel ADatos(Mascota mascota)
    {
        var vm = new MascotaFormViewModel
        {
            Id = Convert.ToInt32(mascota.Codigo),
            Tipo = mascota.Tipo,
            Nombre = mascota.Nombre,
            Edad = mascota.Edad,
            Peso = mascota.Peso,
            EsHembra = mascota.Sexo
        };

        switch (mascota)
        {
            case Perro p: vm.Raza = p.Raza; vm.Tamano = p.Tamano; break;
            case Gato g: vm.Raza = g.Raza; vm.EstaEsterilizado = g.EstaEsterilizado; break;
            case Ave a: vm.Envergadura = a.Envergadura; vm.PuedeVolar = a.PuedeVolar; break;
            case Tortuga t: vm.TipoCaparazon = t.TipoCaparazon; vm.EsAcuatica = t.EsAcuatica; break;
        }
        return vm;
    }
}