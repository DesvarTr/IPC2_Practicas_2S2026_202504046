namespace practica3.Models;

public class AdminViewModel
{
    public ListaMascotas Mascotas { get; set; } = new();
    public Mascota? Activa { get; set; }
    public MascotaFormViewModel Form { get; set; } = new();
}