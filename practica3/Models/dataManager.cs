namespace practica3.Models;

public class MascotaService
{
    private readonly ListaMascotas _lista = new ListaMascotas();
    public ListaMascotas Lista => _lista;
    private int _siguienteId = 1;
    public void Agregar(Mascota m)
    {
        m.Codigo = formatCodigo(_siguienteId++);
        _lista.AgregarMascota(m);
    }

    public Mascota? Buscar(int id) => _lista.BuscarMascota(id);
    public Mascota? BuscarPorNombre(string nombre) => _lista.BuscarMascotaPorNombre(nombre);
    public bool Eliminar(string id) => _lista.EliminarMascotaPorID(id);

    public ListaMascotas ObtenerTodas(){
        return _lista;    
    }

    private string formatCodigo(int codigo)
    {
        return Convert.ToString(codigo).PadLeft(6, '0');
    }

}