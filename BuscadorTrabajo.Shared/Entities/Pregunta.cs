using System.ComponentModel.DataAnnotations;
using BuscadorTrabajo.Shared.Enums;

namespace BuscadorTrabajo.Shared.Entities;

public class Pregunta : IValidatableObject
{
    public int Id { get; set; }

    [Display(Name = "Texto de la pregunta")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.")]
    public string Texto { get; set; } = string.Empty;

    [Display(Name = "Tipo de respuesta")]
    public TipoRespuesta TipoRespuesta { get; set; } = TipoRespuesta.Texto;

    // Solo se usa cuando el tipo es OpcionUnica. Ejemplo: "Junior;Semisenior;Senior"
    [Display(Name = "Opciones")]
    [StringLength(500, ErrorMessage = "El campo {0} no puede superar {1} caracteres.")]
    public string? Opciones { get; set; }

    [Display(Name = "Obligatoria")]
    public bool Obligatoria { get; set; } = true;

    [Display(Name = "Orden")]
    [Range(1, 100, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
    public int Orden { get; set; } = 1;

    // Relación con Publicacion (muchas preguntas pertenecen a una publicación)
    [Display(Name = "Publicación")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una {0}.")]
    public int PublicacionId { get; set; }

    public Publicacion? Publicacion { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (TipoRespuesta == TipoRespuesta.OpcionUnica && string.IsNullOrWhiteSpace(Opciones))
        {
            yield return new ValidationResult(
                "Debe indicar las opciones, separadas por punto y coma, para una pregunta de opción única.",
                new[] { nameof(Opciones) });
        }
    }
}