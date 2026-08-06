using practica1;

bool active = true;
List<Mascota> mascotas = new List<Mascota>();
String[] infoMascota = new String[6];

string generarCodigo(List<Mascota> mascotas)
{
    int numero = mascotas.Count + 1;
    return numero.ToString("D8");
}

while (active){

    Console.WriteLine("================================");
    Console.WriteLine("Bienvenido al sistema de veterninaria");
    Console.WriteLine("================================");
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Agregar mascota");
    Console.WriteLine("2. Gestionar mascotas");
    Console.WriteLine("3. Salir");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":

            string correlativo = generarCodigo(mascotas);
            Console.WriteLine("Ingrese el nombre de la mascota: ");
            infoMascota[0] = Console.ReadLine();
            Console.WriteLine("Ingrese la edad de la mascota: ");
            infoMascota[1] = Console.ReadLine();
            Console.WriteLine("Ingrese el sexo de la mascota (true para hembra, false para macho): ");
            infoMascota[2] = Console.ReadLine();
            Console.WriteLine("Ingrese el peso de la mascota: ");
            infoMascota[3] = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del propietario: ");
            infoMascota[4] = Console.ReadLine();
            Console.WriteLine("Ingrese el estado de salud de la mascota (true para enfermo, false para sano): ");
            infoMascota[5] = Console.ReadLine();

            Console.WriteLine("Ingrese el tipo de mascota (Gato, Perro, Ave, Tortuga): ");
            string tipoMascota = Console.ReadLine();
            switch (tipoMascota.ToLower())
            {
                case "gato":

                    Console.WriteLine("Ingrese la raza del gato: ");
                    string razaGato = Console.ReadLine();
                    Console.WriteLine("Ingrese si el gato está esterilizado (true/false): ");
                    bool estaEsterilizado = bool.Parse(Console.ReadLine());
                    
                    Gato gato = new Gato(infoMascota[0], //nombre
                    int.Parse(infoMascota[1]), //edad
                    infoMascota[4], //propietario
                    correlativo, //codigo
                    bool.Parse(infoMascota[2]), //sexo
                    double.Parse(infoMascota[3]), //peso
                    bool.Parse(infoMascota[5]), //estaEnfermo
                    razaGato, //raza
                    estaEsterilizado); //estaEsterilizado

                    mascotas.Add(gato);
                    break;

                case "perro":
                    Console.WriteLine("Ingrese la raza del perro: ");
                    string razaPerro = Console.ReadLine();
                    Console.WriteLine("Ingrese el tamaño del perro: ");
                    string tamanoPerro = Console.ReadLine();

                    Perro perro = new Perro(infoMascota[0], //nombre
                    int.Parse(infoMascota[1]), //edad
                    infoMascota[4], //propietario
                    correlativo, //codigo
                    bool.Parse(infoMascota[2]), //sexo
                    double.Parse(infoMascota[3]), //peso
                    bool.Parse(infoMascota[5]), //estaEnfermo
                    razaPerro, //raza
                    tamanoPerro); //tamaño del perro

                    mascotas.Add(perro);
                    break;

                case "ave":
                    Console.WriteLine("Ingrese envergadura del ave *(en cm): ");
                    string envergaduraAve = Console.ReadLine();
                    Console.WriteLine("El ave puede volar? (true/false): ");
                    bool puedeVolar = bool.Parse(Console.ReadLine());

                    Ave ave = new Ave(infoMascota[0], //nombre
                    int.Parse(infoMascota[1]), //edad
                    infoMascota[4], //propietario
                    correlativo, //codigo
                    bool.Parse(infoMascota[2]), //sexo
                    double.Parse(infoMascota[3]), //peso
                    bool.Parse(infoMascota[5]), //estaEnfermo
                    double.Parse(envergaduraAve), //envergadura
                    puedeVolar); //puede volar

                    mascotas.Add(ave);
                    break;
                case "tortuga":
                    Console.WriteLine("Ingrese el tipo de caparazón de la tortuga: ");
                    string tipoCaparazon = Console.ReadLine();
                    Console.WriteLine("¿Es acuática? (true/false): ");
                    bool esAcuatica = bool.Parse(Console.ReadLine());

                    Tortuga tortuga = new Tortuga(infoMascota[0], //nombre
                    int.Parse(infoMascota[1]), //edad
                    infoMascota[4], //propietario
                    correlativo, //codigo
                    bool.Parse(infoMascota[2]), //sexo
                    double.Parse(infoMascota[3]), //peso
                    bool.Parse(infoMascota[5]), //estaEnfermo
                    tipoCaparazon, //tipo de caparazón
                    esAcuatica); //es acuática

                    mascotas.Add(tortuga);
                    break;
                default:
                    Console.WriteLine("Tipo de mascota no válido.");
                    break;
            }
            break;

        case "2":

            Console.WriteLine("Seleccione su mascota (Escribir codigo): ");
            for (int i = 0; i < mascotas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mascotas[i].Nombre} ({mascotas[i].Codigo})");
            }
            Mascota mascotaSeleccionada = null;
            string codigoSeleccionado = Console.ReadLine();

            foreach (Mascota m in mascotas)
            {
                if (m.Codigo == codigoSeleccionado)
                {
                    mascotaSeleccionada = m;
                    break;
                }
            }

            if(mascotaSeleccionada == null){
                Console.WriteLine("Mascota no encontrada");
                break;
            }

            Console.WriteLine("Ingrese la opción que desea realizar: ");
            Console.WriteLine("1.  Cambiar estado de salud");
            Console.WriteLine("2.  Calcular dósis de medicamento");
            Console.WriteLine("3.  Mostrar información de la mascota");
            string opcionMascota = Console.ReadLine();

            switch (opcionMascota)
            {
                case "1":
                    mascotaSeleccionada.cambiarEstadoSalud();
                    break;
                case "2":
                    mascotaSeleccionada.calcularDosis(4.28); // Dosis por kg cualquiera de ejemplo
                    break;
                case "3":
                    mascotaSeleccionada.mostrarInformacion();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            break;

        case "3":
            active = false;
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }

}