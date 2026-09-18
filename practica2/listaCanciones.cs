namespace practica2;

public class NodoListaCanciones
{
    private Cancion cancion;
    private NodoListaCanciones siguiente;

    public Cancion Cancion
    {
        get { return cancion; }
        set { cancion = value; }
    }

    public NodoListaCanciones Siguiente
    {
        get { return siguiente; }
        set { siguiente = value; }
    }
    public NodoListaCanciones(Cancion cancion)
    {
        this.cancion = cancion;
        this.siguiente = null;
    }
}

public class ListaCanciones
{
    private NodoListaCanciones cabeza;

    public NodoListaCanciones Cabeza
    {
        get { return cabeza; }
        set { cabeza = value; }
    }

    public ListaCanciones()
    {
        cabeza = null;
    }

    public void AgregarCancion(Cancion cancion)
    {
        NodoListaCanciones nuevoNodo = new NodoListaCanciones(cancion);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            NodoListaCanciones actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }
    
}