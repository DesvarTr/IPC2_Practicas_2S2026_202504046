namespace practica3.Models;

public class Tortuga : Mascota
{
    private string tipoCaparazon;
    private bool esAcuatica;
    protected override double factorAjuste { get; set; } = 0.8;
    public override string Tipo => "Tortuga";
    public override string DetalleEspecifico =>
        $"Caparazón: {TipoCaparazon}, acuática: {(EsAcuatica ? "sí" : "no")}";

    public Tortuga()
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