namespace practica1;

public class Tortuga : Mascota
{
    private string tipoCaparazon;
    private bool esAcuatica;

    public Tortuga(string nombre, int edad, string propietario, string codigo, bool sexo, double peso, bool estaEnfermo,
    string tipoCaparazon, bool esAcuatica) : base(nombre, edad, propietario, codigo, sexo, peso, estaEnfermo)
    
    {
        this.tipoCaparazon = tipoCaparazon;
        this.esAcuatica = esAcuatica;
    }

    public override void calcularDosis(double dosisPorKg)
    {
        double dosis = Peso * dosisPorKg * 0.8;
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
        Console.WriteLine($"Tipo de caparazón: {tipoCaparazon}");
        Console.WriteLine($"Es acuática: {(esAcuatica ? "Sí" : "No")}");
    }
    public string TipoCaparazon
    {
        get { return tipoCaparazon; }
        set { tipoCaparazon = value; }
    }

    public bool EsAcuatica
    {
        get { return esAcuatica; }
        set { esAcuatica = value; }
    }
}