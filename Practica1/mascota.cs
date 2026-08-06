namespace practica1
{
    public abstract class Mascota
    {
        private string nombre;
        private bool sexo; //True = Hembra, False = Macho
        private double peso;
        private int edad;
        private string propietario;
        private string codigo;
        private bool estaEnfermo;

        public abstract void calcularDosis(double dosisPorKg);

        public void cambiarEstadoSalud()
        {
            estaEnfermo = !estaEnfermo;
        }

        public abstract void mostrarInformacion();
        public Mascota(string nombre, int edad, string propietario, string codigo, bool sexo, double peso, bool estaEnfermo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.propietario = propietario;
            this.codigo = codigo;
            this.sexo = sexo;
            this.peso = peso;
            this.estaEnfermo = estaEnfermo;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public bool Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public string Propietario
        {
            get { return propietario; }
            set { propietario = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public bool EstaEnfermo
        {
            get { return estaEnfermo; }
            set { estaEnfermo = value; }
        }

    }
}