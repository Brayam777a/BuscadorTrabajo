using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuscadorTrabajo.Shared.Enums;
using System.Text.Json.Serialization;
namespace BuscadorTrabajo.Shared.Entities;

public class Publicacion : IValidatableObject
{
    public int Id { get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.")]
    public string Titulo { get; set; } = string.Empty;

    [Display(Name = "Descripción")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(4000, MinimumLength = 20, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    [Display(Name = "Modalidad")]
    public ModalidadTrabajo Modalidad { get; set; } = ModalidadTrabajo.Presencial;

    [Display(Name = "Tipo de contrato")]
    public TipoContrato TipoContrato { get; set; } = TipoContrato.Indefinido;

    [Display(Name = "Nivel de experiencia")]
    public NivelExperiencia NivelExperiencia { get; set; } = NivelExperiencia.SinExperiencia;

    [Display(Name = "Ciudad")]
    [StringLength(100, ErrorMessage = "El campo {0} no puede superar {1} caracteres.")]
    public string? Ciudad { get; set; }

    [Display(Name = "Salario mínimo")]
    [Range(0, 1000000000, ErrorMessage = "El campo {0} debe ser un valor positivo.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SalarioMinimo { get; set; }

    [Display(Name = "Salario máximo")]
    [Range(0, 1000000000, ErrorMessage = "El campo {0} debe ser un valor positivo.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? SalarioMaximo { get; set; }

    [Display(Name = "Estado")]
    public EstadoPublicacion Estado { get; set; } = EstadoPublicacion.Activa;

    [Display(Name = "Fecha de publicación")]
    public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;

    [Display(Name = "Fecha de cierre")]
    public DateTime? FechaCierre { get; set; }

    // Relación con Categoria (muchas publicaciones pertenecen a una categoría)
    [Display(Name = "Categoría")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una {0}.")]
    public int CategoriaId { get; set; }

    public Categoria? Categoria { get; set; }
    [JsonIgnore]
    public ICollection<Pregunta>? Preguntas { get; set; }
    // Regla de negocio que involucra dos campos
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SalarioMinimo.HasValue && SalarioMaximo.HasValue && SalarioMaximo < SalarioMinimo)
        {
            yield return new ValidationResult(
                "El salario máximo no puede ser menor que el salario mínimo.",
                new[] { nameof(SalarioMaximo) });
        }

        if (FechaCierre.HasValue && FechaCierre < FechaPublicacion)
        {
            yield return new ValidationResult(
                "La fecha de cierre no puede ser anterior a la fecha de publicación.",
                new[] { nameof(FechaCierre) });
        }
    }
}