namespace practica3.Models;

public class Perro : Mascota
{
    private string raza;
    private string tamano;

    protected override double factorAjuste { get; set; } = 1;
    public override string Tipo => "Perro";
    public override string DetalleEspecifico => $"Raza: {raza}, tamaño: {tamano}";

    public Perro()
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
        Console.WriteLine($"Tamaño: {tamano}");
    }

    public string Raza
    {
        get { return raza; }
        set { raza = value; }
    }

    public string Tamano
    {
        get { return tamano; }
        set { tamano = value; }
    }

}