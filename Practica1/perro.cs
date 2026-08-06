namespace practica1;

public class Perro : Mascota
{
    private string raza;
    private string tamano;

    public Perro(string nombre, int edad, string propietario, string codigo, bool sexo, double peso, bool estaEnfermo,
    string raza, string tamano) : base(nombre, edad, propietario, codigo, sexo, peso, estaEnfermo)

    {
        this.raza = raza;
        this.tamano = tamano;
    }

    public override void calcularDosis(double dosisPorKg)
    {
        double dosis = Peso * dosisPorKg;
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