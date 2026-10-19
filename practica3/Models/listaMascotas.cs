namespace practica3.Models;

class NodoListaMascotas
{
    private Mascota mascota;

    public Mascota Mascota
    {
        get { return mascota; }
        set { mascota = value; }
    }
    private NodoListaMascotas siguiente;

    public NodoListaMascotas Siguiente
    {
        get { return siguiente; }
        set { siguiente = value; }
    }

    public NodoListaMascotas(Mascota mascota)
    {
        this.mascota = mascota;
        this.siguiente = null;
    }
}

public class ListaMascotas
{
    private NodoListaMascotas head;
    private NodoListaMascotas rear;

    public int Cantidad { get; private set; }

    public ListaMascotas()
    {
        this.head = null;
        this.rear = null;
        this.Cantidad = 0;
    }

    public void AgregarMascota(Mascota mascota)
    {
        NodoListaMascotas nuevoNodo = new NodoListaMascotas(mascota);
        if (head == null)
        {
            head = nuevoNodo;
            rear = nuevoNodo;
        }
        else
        {
            rear.Siguiente = nuevoNodo;
            rear = nuevoNodo;
        }
        Cantidad++;
    }

    public void EliminarMascota(string nombre)
    {
        if (head == null)
        {
            Cantidad = 0;
            return;
        }

        if (head.Mascota.Nombre == nombre)
        {
            head = head.Siguiente;
            if (head == null)
            {
                rear = null;
            }
            Cantidad--;
            return;
        }

        NodoListaMascotas actual = head;
        while (actual.Siguiente != null && actual.Siguiente.Mascota.Nombre != nombre)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            if (actual.Siguiente == null)
            {
                rear = actual;
            }
        }
        Cantidad--;
    }

    public bool EliminarMascotaPorID(string codigo)
    {
        if (head == null)
        {
            Cantidad = 0;
            return false;
        }

        if (head.Mascota.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
        {
            head = head.Siguiente;
            if (head == null)
            {
                rear = null;
            }
            Cantidad--;
            return true;
        }

        NodoListaMascotas actual = head;
        while (actual.Siguiente != null && !actual.Siguiente.Mascota.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            if (actual.Siguiente == null)
            {
                rear = actual;
            }
            Cantidad--;
            return true;
        }
        return false;
    }

    public Mascota ObtenerEn(int indice)
    {
        if (indice < 0 || indice >= Cantidad)
        {
            throw new ArgumentOutOfRangeException(nameof(indice), "Índice fuera de rango.");
        }

        NodoListaMascotas actual = head;
        for (int i = 0; i < indice; i++)
        {
            actual = actual.Siguiente;
        }
        return actual.Mascota;
    }

    public Mascota BuscarMascota(int codigo)
    {
        NodoListaMascotas actual = head;
        while (actual != null)
        {
            if (actual.Mascota.Codigo == codigo.ToString().PadLeft(6, '0'))
            {
                return actual.Mascota;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

    public Mascota BuscarMascotaPorNombre(string nombre)
    {
        NodoListaMascotas actual = head;
        while (actual != null)
        {
            if (actual.Mascota.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return actual.Mascota;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

}