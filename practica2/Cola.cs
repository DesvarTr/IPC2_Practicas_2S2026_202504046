namespace practica2;
using System.Text;
using System.Diagnostics;
public class NodoCola
{
    private Cancion data;

    public Cancion Data
    {
        get{ return data; }
        set{ data = value; }
    }
    private NodoCola siguiente;

    public NodoCola Siguiente
    {
        get{ return siguiente; }
        set{ siguiente = value; }
    }
    public NodoCola(Cancion data)
    {
        this.data = data;
        this.siguiente = null;
    }
}

public class Cola
{
    private NodoCola head;
    public NodoCola Head
    {
        get{return head;}
        set{head = value;}
    }
    private NodoCola rear;

    private int duracion;
    public int getDuracion()
    {
        return duracion;
    }

    public Cola()
    {
        this.duracion = 0;
    }

    public void enqueue(Cancion data)
    {
        NodoCola newNode = new NodoCola(data);
        if(head == null)
        {
            head = newNode;
            rear = newNode;
        } else
        {
            rear.Siguiente = newNode;
            rear = newNode;
        }
        duracion+=Convert.ToInt32(data.Duracion);
    }
    
    public Cancion dequeue()
    {
        if (isEmpty())
        {
            MessageBox.Show("La cola está vacía");
            return null;
        }
        Cancion retornable = head.Data;
        if(head.Siguiente != null)
        {
            head = head.Siguiente;
        } else
        {
            head = null;
            rear = null;
        }
        duracion-=Convert.ToInt32(retornable.Duracion);
        return retornable;
    }

    private bool isEmpty(){return head==null;}

    public void Graficar()
    {
        string dotFilePath = "cola.dot";
        string pngFilePath = "cola.png";
        
        if (head == null)
        {   
            // Limpiar archivos anteriores si la cola está vacía
            if (File.Exists(dotFilePath)) File.Delete(dotFilePath);
            if (File.Exists(pngFilePath)) File.Delete(pngFilePath);
            return;
        }

        StringBuilder dot = new StringBuilder();
        
        dot.AppendLine("digraph Cola {");
        dot.AppendLine("    rankdir=LR;"); // <--- Esto hace que la cola sea horizontal
        dot.AppendLine("    node [shape=box];"); // Estilo de caja para los elementos

        // Recorrer la cola desde el inicio (head)
        var actual = head;
        int index = 0;
        string ultimoId = "";

        while (actual != null)
        {
            string idActual = $"nodo_{index}";
            // Limpiamos y escapamos el título por si tiene comillas o espacios
            string etiqueta = actual.Data.Titulo.Replace("\"", "\\\"");
            
            // Definir el nodo
            dot.AppendLine($"    {idActual} [label=\"{etiqueta}\"];");

            // Conectar con el nodo anterior para formar la secuencia de la cola
            if (ultimoId != "")
            {
                dot.AppendLine($"    {ultimoId} -> {idActual};");
            }

            ultimoId = idActual;
            actual = actual.Siguiente; // Asumiendo que tu nodo tiene un puntero Siguiente
            index++;
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
                    Console.WriteLine($"¡Gráfica de la cola generada exitosamente en: {pngFilePath}!");
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
}