namespace practica1;

public class Ave : Mascota
{
    private double envergadura;
    private bool puedeVolar;

    public Ave(string nombre, int edad, string propietario, string codigo, bool sexo, double peso, bool estaEnfermo,
    double envergadura, bool puedeVolar) : base(nombre, edad, propietario, codigo, sexo, peso, estaEnfermo)
    
    {
        this.envergadura = envergadura;
        this.puedeVolar = puedeVolar;
    }

    public override void calcularDosis(double dosisPorKg)
    {
        double dosis = Peso * dosisPorKg * 0.5;
        Console.WriteLine($"La dosis para {Nombre} es: {dosis} mg");
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