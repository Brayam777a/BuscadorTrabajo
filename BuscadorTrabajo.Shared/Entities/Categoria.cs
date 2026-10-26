using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuscadorTrabajo.Shared.Entities;

public class Categoria
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Display(Name = "Descripción")]
    [StringLength(300, ErrorMessage = "El campo {0} no puede superar {1} caracteres.")]
    public string? Descripcion { get; set; }

    public bool Activa { get; set; } = true;

    [JsonIgnore]
    public ICollection<Publicacion>? Publicaciones { get; set; }
}