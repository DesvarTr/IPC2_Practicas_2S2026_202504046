using System.Runtime.InteropServices.Swift;

namespace practica1;

public class Gato : Mascota
{
    private string raza;
    private bool estaEsterilizado;

    public Gato(string nombre, int edad, string propietario, string codigo, bool sexo, double peso, bool estaEnfermo,
    string raza, bool estaEsterilizado) : base(nombre, edad, propietario, codigo, sexo, peso, estaEnfermo)

    {
        this.raza = raza;
        this.estaEsterilizado = estaEsterilizado;
    }

    public override void calcularDosis(double dosisPorKg)
    {
        double dosis = Peso * dosisPorKg * 0.9;
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