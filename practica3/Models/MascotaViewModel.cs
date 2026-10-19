using System.ComponentModel.DataAnnotations;

namespace practica3.Models;

public class MascotaFormViewModel : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Seleccione el tipo de mascota.")]
    public string Tipo { get; set; } = string.Empty;

    // Atributos generales
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(60)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La edad es obligatoria.")]
    [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100.")]
    public int? Edad { get; set; }

    [Required(ErrorMessage = "El peso es obligatorio.")]
    [Range(0.01, 500, ErrorMessage = "El peso debe estar entre 0.01 y 500 kg.")]
    public double? Peso { get; set; }
    public bool EsHembra { get; set; }

    // Atributos propios. Son nullable a propósito: solo aplican al tipo elegido.
    public string? Raza { get; set; }                 // Perro, Gato
    public string? Tamano { get; set; }               // Perro
    public bool EstaEsterilizado { get; set; }        // Gato
    public double? Envergadura { get; set; }          // Ave
    public bool PuedeVolar { get; set; }              // Ave
    public string? TipoCaparazon { get; set; }        // Tortuga
    public bool EsAcuatica { get; set; }              // Tortuga

    // Valida solo los campos propios del tipo seleccionado
    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        switch (Tipo)
        {
            case "Perro":
                if (string.IsNullOrWhiteSpace(Raza))
                    yield return new ValidationResult("La raza es obligatoria.", new[] { nameof(Raza) });
                if (Tamano is not ("Grande" or "Mediano" or "Pequeño"))
                    yield return new ValidationResult("Elija un tamaño.", new[] { nameof(Tamano) });
                break;
            case "Gato":
                if (string.IsNullOrWhiteSpace(Raza))
                    yield return new ValidationResult("La raza es obligatoria.", new[] { nameof(Raza) });
                break;
            case "Ave":
                if (Envergadura is null or <= 0)
                    yield return new ValidationResult("Indique una envergadura mayor a 0.", new[] { nameof(Envergadura) });
                break;
            case "Tortuga":
                if (string.IsNullOrWhiteSpace(TipoCaparazon))
                    yield return new ValidationResult("Indique el tipo de caparazón.", new[] { nameof(TipoCaparazon) });
                break;
            default:
                yield return new ValidationResult("Tipo de mascota no válido.", new[] { nameof(Tipo) });
                break;
        }
    }
}
