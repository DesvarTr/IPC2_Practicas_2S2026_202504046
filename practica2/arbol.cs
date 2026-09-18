using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace practica2;
public class Arbol
{

    private NodoArbol Raiz;
    private int ObtenerAltura(NodoArbol nodo)
    {
        if (nodo == null)
            return 0;

        return nodo.Altura;
    }

    private int FactorBalance(NodoArbol nodo)
    {
        if (nodo == null)
            return 0;

        return ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
    }

    private NodoArbol RotacionDerecha(NodoArbol y)
    {
        // Graficar();
        NodoArbol x = y.Izquierdo;
        NodoArbol temporal = x.Derecho;

        x.Derecho = y;
        y.Izquierdo = temporal;

        y.Altura = 1 + Math.Max(
            ObtenerAltura(y.Izquierdo),
            ObtenerAltura(y.Derecho)
        );

        x.Altura = 1 + Math.Max(
            ObtenerAltura(x.Izquierdo),
            ObtenerAltura(x.Derecho)
        );

        return x;
    }

    private NodoArbol RotacionIzquierda(NodoArbol x)
    {
        // Graficar();
        NodoArbol y = x.Derecho;
        NodoArbol temporal = y.Izquierdo;

        y.Izquierdo = x;
        x.Derecho = temporal;

        x.Altura = 1 + Math.Max(
            ObtenerAltura(x.Izquierdo),
            ObtenerAltura(x.Derecho)
        );

        y.Altura = 1 + Math.Max(
            ObtenerAltura(y.Izquierdo),
            ObtenerAltura(y.Derecho)
        );

        return y;
    }

    private NodoArbol Insertar(NodoArbol nodo, Cancion cancion)
    {
        // 1. Insertar como ABB
        if (nodo == null)
            return new NodoArbol(cancion);
        
        int comparacion = cancion.Titulo.CompareTo(nodo.Titulo);

        if (comparacion < 0)
            nodo.Izquierdo = Insertar(nodo.Izquierdo, cancion);
        else if (comparacion > 0)
            nodo.Derecho = Insertar(nodo.Derecho, cancion);
        else
            return nodo;

        // 2. Actualizar altura
        nodo.Altura = 1 + Math.Max(
            ObtenerAltura(nodo.Izquierdo),
            ObtenerAltura(nodo.Derecho)
        );

        // 3. Calcular balance
        int balance = FactorBalance(nodo);

        // 4. Caso LL (Izquierda-Izquierda)
        if (balance > 1 && nodo.Izquierdo != null && cancion.Titulo.CompareTo(nodo.Izquierdo.Titulo) < 0)
        {
            return RotacionDerecha(nodo);
        }

        // 5. Caso RR (Derecha-Derecha)
        if (balance < -1 && nodo.Derecho != null && cancion.Titulo.CompareTo(nodo.Derecho.Titulo) > 0)
        {
            return RotacionIzquierda(nodo);
        }

        // 6. Caso LR (Izquierda-Derecha)
        if (balance > 1 && nodo.Izquierdo != null && cancion.Titulo.CompareTo(nodo.Izquierdo.Titulo) > 0)
        {
            nodo.Izquierdo = RotacionIzquierda(nodo.Izquierdo);
            return RotacionDerecha(nodo);
        }

        // 7. Caso RL (Derecha-Izquierda)
        if (balance < -1 && nodo.Derecho != null && cancion.Titulo.CompareTo(nodo.Derecho.Titulo) < 0)
        {
            nodo.Derecho = RotacionDerecha(nodo.Derecho);
            return RotacionIzquierda(nodo);
        }

        return nodo;
    }

    public void Insertar(Cancion cancion)
    {
        Raiz = Insertar(Raiz, cancion);
    }

    public void ImprimirInOrder()
    {
        InOrder(Raiz);
        MessageBox.Show("");
    }

    public NodoArbol Buscar(string titulo)
    {
        return BuscarNodo(Raiz, titulo);
    }

    private NodoArbol BuscarNodo(NodoArbol nodo, string titulo)
    {
        if (nodo == null)
            return null;

        int comparacion = titulo.CompareTo(nodo.Titulo);

        if (comparacion < 0)
        {
            return BuscarNodo(nodo.Izquierdo, titulo);
        }
        else if (comparacion > 0)
        {
            return BuscarNodo(nodo.Derecho, titulo);
        }
        else
        {
            return nodo;
        }
    }
    private void InOrder(NodoArbol nodo_actual)
    {
        if (nodo_actual != null)
        {
            InOrder(nodo_actual.Izquierdo);
            MessageBox.Show($"{nodo_actual.Titulo} ");
            InOrder(nodo_actual.Derecho);
        }
    }

    public void Graficar()
    {
        string dotFilePath = "arbol.dot";
        string pngFilePath = "arbol.png";
        
        if (Raiz == null)
        {
            MessageBox.Show("El árbol está vacío.");
            
            return;
        }

        StringBuilder dot = new StringBuilder();
        

        dot.AppendLine("digraph AVL {");
        dot.AppendLine("    node [shape=circle];");

        if (Raiz != null)
        {
            GenerarDot(Raiz, dot);
        }

        dot.AppendLine("}");

        File.WriteAllText(dotFilePath, dot.ToString());

        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dot",
                Arguments = $"-Tpng {dotFilePath} -o {pngFilePath}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    Console.WriteLine($"¡Gráfica generada exitosamente en: {pngFilePath}!");
                    //Process.Start(new ProcessStartInfo(pngFilePath) { UseShellExecute = true });
                }
                else
                {
                    Console.WriteLine("Error en Graphviz: " + process.StandardError.ReadToEnd());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("No se pudo ejecutar Graphviz. " + ex.Message);
        }
    }

    private void GenerarDot(NodoArbol nodo, StringBuilder dot)
    {
        if (nodo == null)
            return;

        // Nodo izquierdo
        if (nodo.Izquierdo != null)
        {
            dot.AppendLine(
                $"    \"{nodo.Titulo}\" -> \"{nodo.Izquierdo.Titulo}\";"
            );

            GenerarDot(nodo.Izquierdo, dot);
        }

        // Nodo derecho
        if (nodo.Derecho != null)
        {
            dot.AppendLine(
                $"    \"{nodo.Titulo}\" -> \"{nodo.Derecho.Titulo}\";"
            );

            GenerarDot(nodo.Derecho, dot);
        }
    }
}