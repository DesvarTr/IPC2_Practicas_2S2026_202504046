namespace practica2;
public class NodoArbol
{
    private Cancion cancion;
    protected NodoArbol izquierdo;
    protected NodoArbol derecho;
    protected int altura;

    public NodoArbol Izquierdo
    {
        get { return izquierdo; }
        set { izquierdo = value; }
    }
    public NodoArbol Derecho
    {
        get { return derecho; }
        set { derecho = value; }
    }
    public int Altura
    {
        get { return altura; }
        set { altura = value; }
    }

    public string Titulo
    {
        get { return cancion.Titulo; }
        set { cancion.Titulo = value; }
    }

    public Cancion Cancion
    {
        get { return cancion; }
        set { cancion = value; }
    }

    public NodoArbol(Cancion cancion)
    {
        this.cancion = cancion;
        this.izquierdo = null;
        this.derecho = null;
        this.altura = 1;
    }
}