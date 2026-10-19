using System.Runtime.InteropServices.Swift;

namespace practica3.Models;

public class Gato : Mascota
{
    private string raza;
    private bool estaEsterilizado;

    protected override double factorAjuste { get; set; } = 0.9;
    public override string Tipo => "Gato";
    public override string DetalleEspecifico => $"Raza: {raza}, esterilizado: {(EstaEsterilizado ? "sí" : "no")}";

    public Gato()
    {
    }

    public override double calcularDosis(double dosisPorKg)
    {
        double dosis = Peso * dosisPorKg * factorAjuste;
        Console.WriteLine($"La dosis para {Nombre} es: {dosis} mg");
        return dosis;
    }

    public override void mostrarInformacion(){
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Sexo: {(Sexo ? "Hembra" : "Macho")}");
        Console.WriteLine($"Peso: {Peso} kg");
        Console.WriteLine($"Propietario: {Propietario}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Estado de salud: {(EstaEnfermo ? "Enfermo" : "Sano")}");
        Console.WriteLine($"Raza: {raza}");
        Console.WriteLine($"Esta esterilizado: {(estaEsterilizado ? "Sí" : "No")}");
    }

    public string Raza
    {
        get { return raza; }
        set { raza = value; }
    }
    public bool EstaEsterilizado
    {
        get { return estaEsterilizado; }
        set { estaEsterilizado = value; }
    }

}