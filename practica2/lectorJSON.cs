namespace practica2;

using System.Text.Json;
public class LectorDatosJson
{
    public ListaCanciones ExtraerCanciones(string rutaArchivo)
    {
        ListaCanciones listaCanciones = new ListaCanciones();
        string jsonString = File.ReadAllText(rutaArchivo);

        var opciones = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        Cancion[] cancionesArray = JsonSerializer.Deserialize<Cancion[]>(jsonString, opciones);
        if (cancionesArray == null)
        {
            throw new JsonException("Error al deserializar el archivo JSON");
        }

        if (cancionesArray != null)
        {
            foreach (var cancion in cancionesArray)
            {
                listaCanciones.AgregarCancion(cancion);
            }
        }

    return listaCanciones;

    }
}