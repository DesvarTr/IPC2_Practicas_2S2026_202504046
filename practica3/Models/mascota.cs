namespace practica3.Models
{
    public abstract class Mascota
    {
        private string nombre;
        private bool sexo; //True = Hembra, False = Macho
        public string Genero => sexo ? "Hembra" : "Macho"; 
        private double peso;
        private int edad;
        private string propietario;
        private string codigo;
        private bool estaEnfermo;
        protected abstract double factorAjuste { get; set; }
        public string Estado => EstaEnfermo ? "Enferma" : "Sana";
        public abstract string Tipo { get; }
        public abstract string DetalleEspecifico { get; }
        public double FactorAjuste
        {
            get { return factorAjuste; }
            set { factorAjuste = value; }
        }

        public abstract double calcularDosis(double dosisPorKg);

        public void cambiarEstadoSalud()
        {
            estaEnfermo = !estaEnfermo;
        }

        public abstract void mostrarInformacion();
        public Mascota()
        {
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