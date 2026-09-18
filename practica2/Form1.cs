namespace practica2;
using System;
using System.Linq.Expressions;
using System.Text.Json;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private ListaCanciones canciones;

    private Arbol arbolCanciones;
    private Cola colaCanciones;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private TextBox txtInput;
    private TextBox searchInput;

    private TextBox txtDisplay1;
    private TextBox txtDisplaySearch;
    private Button btnLoad;
    private Button btnSearch;
    private Button btnSiguiente;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;

    private Label lblInfo;
    private Label lblIngreso;
    private Label lblBusqueda;
    private Label lblCola;

    public Form1(ListaCanciones canciones)
    {
        this.canciones = canciones;
        this.arbolCanciones = new Arbol();
        this.colaCanciones = new Cola();
        InitializeComponent();
        SetupCustomUI();
    }

    private void SetupCustomUI()
    {
        tabControl1 = new TabControl();
        tabControl1.Location = new System.Drawing.Point(20, 20);
        tabControl1.Size = new System.Drawing.Size(945, 925);

        tabPage1 = new TabPage("Ingreso datos");
        tabPage2 = new TabPage("Visualizar arbol");
        tabPage3 = new TabPage("Cola de reproduccion");

        // Pagina carga y busqueda
        lblIngreso = new Label();
        lblIngreso.Location = new System.Drawing.Point(20, 30);
        lblIngreso.Size = new System.Drawing.Size(600, 30);
        lblIngreso.Text = "Ingrese el nombre del archivo a cargar";
        lblIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        txtInput = new TextBox();
        txtInput.Location = new System.Drawing.Point(20, 70);
        txtInput.Size = new System.Drawing.Size(450, 20);
        txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        btnLoad = new Button();
        btnLoad.Location = new System.Drawing.Point(20, 110);
        btnLoad.Size = new System.Drawing.Size(180, 50);
        btnLoad.Text = "¡Cargar!";
        btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        btnLoad.Click += new EventHandler(BtnLoad_Click);

        lblBusqueda = new Label();
        lblBusqueda.Location = new System.Drawing.Point(20, 270);
        lblBusqueda.Size = new System.Drawing.Size(600, 30);
        lblBusqueda.Text = "Ingrese la cancion a buscar";
        lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        searchInput = new TextBox();
        searchInput.Location = new System.Drawing.Point(20, 320);
        searchInput.Size = new System.Drawing.Size(450, 20);
        searchInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        btnSearch = new Button();
        btnSearch.Location = new System.Drawing.Point(20, 360);
        btnSearch.Size = new System.Drawing.Size(180, 50);
        btnSearch.Text = "¡Buscar!";
        btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        btnSearch.Click += new EventHandler(BtnSearch_Click);

        txtDisplaySearch = new TextBox();
        txtDisplaySearch.Location = new System.Drawing.Point(40, 440);
        txtDisplaySearch.Size = new System.Drawing.Size(600, 150);
        txtDisplaySearch.Multiline = true;
        txtDisplaySearch.ReadOnly = true;
        txtDisplaySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        // Imagenes paginas 2 y 3
        pictureBox1 = new PictureBox();
        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

        pictureBox2 = new PictureBox();
        pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
        pictureBox2.Location = new System.Drawing.Point(40, 620);

        // Agregar a la pestaña 1
        tabPage1.Controls.Add(lblIngreso);
        tabPage1.Controls.Add(txtInput);
        tabPage1.Controls.Add(btnLoad);
        tabPage1.Controls.Add(lblBusqueda);
        tabPage1.Controls.Add(searchInput);
        tabPage1.Controls.Add(btnSearch);
        tabPage1.Controls.Add(txtDisplaySearch);

        // Agregar a la pestaña 2
        tabPage2.AutoScroll = true;
        tabPage2.Controls.Add(pictureBox1);

        // Cola
        txtDisplay1 = new TextBox();
        txtDisplay1.Location = new System.Drawing.Point(40, 50);
        txtDisplay1.Size = new System.Drawing.Size(600, 350);
        txtDisplay1.Multiline = true;
        txtDisplay1.ReadOnly = true;
        txtDisplay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        btnSiguiente = new Button();
        btnSiguiente.Location = new System.Drawing.Point(40, 420);
        btnSiguiente.Size = new System.Drawing.Size(160, 50);
        btnSiguiente.Text = "Siguiente";
        btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        btnSiguiente.Click += new EventHandler(BtnSiguiente_Click);

        //Label tiempo
        lblInfo = new Label();
        lblInfo.Location = new System.Drawing.Point(40, 500);
        lblInfo.Size = new System.Drawing.Size(600, 30);
        lblInfo.Text = "Duración restante: "+Convert.ToString(colaCanciones.getDuracion());
        lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        //Label Cola
        lblCola = new Label();
        lblCola.Location = new System.Drawing.Point(40, 550);
        lblCola.Size = new System.Drawing.Size(600, 30);
        lblCola.Text = "Cola de reproducción";
        lblCola.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        // Agregar controles a la pestaña 3
        tabPage3.Controls.Add(txtDisplay1);
        tabPage3.Controls.Add(btnSiguiente);
        tabPage3.Controls.Add(pictureBox2);
        tabPage3.Controls.Add(lblInfo);
        tabPage3.Controls.Add(lblCola);

        // Agregar paginas al organizador de tabs
        tabControl1.TabPages.Add(tabPage1);
        tabControl1.TabPages.Add(tabPage2);
        tabControl1.TabPages.Add(tabPage3);

        tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);

        this.Controls.Add(tabControl1);
    }

    private void BtnLoad_Click(object sender, EventArgs e)
    {
        string message = txtInput.Text;
        canciones.Cabeza = null; //Reinicia la lista de cargados
        LectorDatosJson lector = new LectorDatosJson();
        try 
        {
            canciones = lector.ExtraerCanciones(message);
            MessageBox.Show(message + " cargado exitosamente.");
        }
        catch (FileNotFoundException)
        {
            try{
                canciones = lector.ExtraerCanciones(message + ".json");
                MessageBox.Show("Archivo " + message + ".json" + " cargado exitosamente.");
            } catch (FileNotFoundException)
            {
                MessageBox.Show($"Archivo {message + ".json"} no encontrado");
                return;
            }
        }   
        catch (JsonException ex)
        {
            MessageBox.Show("Error al deserializar el archivo JSON: " + ex.Message);
            return;
        } catch (Exception ex)
        {
            MessageBox.Show("Ingrese un nombre de archivo válido" + ex.Message);
            return;
        }

        NodoListaCanciones tempNode = canciones.Cabeza;
        while (tempNode != null)
        {
            //MessageBox.Show(tempNode.Cancion.Titulo);
            arbolCanciones.Insertar(tempNode.Cancion);
            colaCanciones.enqueue(tempNode.Cancion);
            tempNode = tempNode.Siguiente;
        }

        // Actualizar label de tiempo
        lblInfo.Text = "Duración restante: "+Convert.ToString(colaCanciones.getDuracion());

        txtInput.Clear();
        txtInput.Focus();
    }

    private void BtnSearch_Click(object sender, EventArgs e)
    {
        string tituloBuscado = searchInput.Text.Trim();

        if (string.IsNullOrEmpty(tituloBuscado))
        {
            MessageBox.Show("Por favor ingresa un título para buscar.");
            return;
        }

        // Suponiendo que 'tuInstanciaDelArbol' es el objeto de tu clase AVL
        NodoArbol resultado = arbolCanciones.Buscar(tituloBuscado);

        if (resultado != null)
        {
            txtDisplaySearch.Text = $"¡Canción encontrada!\r\n\r\n" +
                                $"Título: {resultado.Cancion.Titulo}\r\n" +
                                $"Artista: {resultado.Cancion.Artista}\r\n" +
                                $"Género: {resultado.Cancion.Genero}\r\n" +
                                $"Duración: {resultado.Cancion.Duracion} minutos";
        }
        else
        {
            txtDisplaySearch.Text = "No se encontró ninguna canción con ese título en el árbol.";
        }
        searchInput.Clear();
        searchInput.Focus();
    }
    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab == tabPage2)
        {
            arbolCanciones.Graficar();
        }

        if (File.Exists("arbol.png"))
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }

            using (var stream = new FileStream("arbol.png", FileMode.Open, FileAccess.Read))
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        if (tabControl1.SelectedTab == tabPage3)
        {
            colaCanciones.Graficar();
        }

        if (File.Exists("cola.png"))
        {
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
            }

            using (var stream = new FileStream("cola.png", FileMode.Open, FileAccess.Read))
            {
                pictureBox2.Image = Image.FromStream(stream);
            }
        }

    }

    private void BtnSiguiente_Click(object sender, EventArgs e)
    {
        if (colaCanciones.Head==null)
        {
            txtDisplay1.Text = "No hay elementos en la cola.";
            return;
        } else
        {
            MostrarElementoActual();
        }

        colaCanciones.Graficar();

        if (pictureBox2.Image != null)
        {
            pictureBox2.Image.Dispose();
            pictureBox2.Image = null;
        }

        if (File.Exists("cola.png"))
        {
            using (var stream = new FileStream("cola.png", FileMode.Open, FileAccess.Read))
            {
                pictureBox2.Image = Image.FromStream(stream);
            }
        }
        else
        {
            pictureBox2.Image = null;
        }

        lblInfo.Text = "Duración restante: "+Convert.ToString(colaCanciones.getDuracion());

    }

    private void MostrarElementoActual()
    {
        Cancion c = colaCanciones.dequeue();
            txtDisplay1.Text =  $"Título: {c.Titulo}\r\n" +
                            $"Artista: {c.Artista}\r\n" +
                            $"Género: {c.Genero}\r\n" +
                            $"Duración: {c.Duracion} minutos";
    }
}
