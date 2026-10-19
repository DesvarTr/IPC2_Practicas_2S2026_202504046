namespace practica3.Models;

public class Ave : Mascota
{
    private double envergadura;
    private bool puedeVolar;
    protected override double factorAjuste { get; set; } = 0.5;
    public override string Tipo => "Ave";
    public override string DetalleEspecifico =>
        $"Envergadura: {Envergadura:0.##} cm, puede volar: {(PuedeVolar ? "sí" : "no")}";

    public Ave()
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
        Console.WriteLine($"Envergadura: {envergadura} cm");
        Console.WriteLine($"Puede volar: {(puedeVolar ? "Sí" : "No")}");
    }

    public double Envergadura
    {
        get { return envergadura; }
        set { envergadura = value; }
    }

    public bool PuedeVolar
    {
        get { return puedeVolar; }
        set { puedeVolar = value; }
    }

}