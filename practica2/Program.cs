namespace practica2;

static class Program
{
    [STAThread]
    static void Main()
    {
        ListaCanciones canciones = new ListaCanciones();
        Arbol arbolCanciones = new Arbol();

        // Borrar archivos de imagen
        if (File.Exists("arbol.dot"))
        {
            File.Delete("arbol.dot");
        }

        if (File.Exists("arbol.png"))
        {
            File.Delete("arbol.png");
        }

        if (File.Exists("cola.dot")) File.Delete("cola.dot");
        if (File.Exists("cola.png")) File.Delete("cola.png");

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(canciones));
    }    
}