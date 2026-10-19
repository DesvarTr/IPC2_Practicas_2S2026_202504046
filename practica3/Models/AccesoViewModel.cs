namespace practica3.Models;

public class AccesoViewModel
{
    public ListaMascotas Mascotas { get; set; } = new();
    public Mascota? Detalle { get; set; }
    public MascotaFormViewModel Form { get; set; } = new();
}