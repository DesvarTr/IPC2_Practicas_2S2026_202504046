namespace practica2;

public class Cancion
{
    private string titulo;
    private string artista;
    private string genero;
    private int duracion;

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Artista
    {
        get { return artista; }
        set { artista = value; }
    }

    public string Genero
    {
        get { return genero; }
        set { genero = value; }
    }

    public int Duracion
    {
        get { return duracion; }
        set { duracion = value; }
    }

    public Cancion(string titulo, string artista, string genero, int duracion)
    {
        this.titulo = titulo;
        this.artista = artista;
        this.genero = genero;
        this.duracion = duracion;
    }
}