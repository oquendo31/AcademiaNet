using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.DTOs;

public class InstitutionDTO
{
    [Key]
    public int InstitutionID { get; set; } // Identificador único de la institución

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!; // Nombre de la institución

    [MaxLength(100)]
    public string? Location { get; set; } // Ubicación de la institución (opcional)

    [MaxLength(100)]
    public string? Description { get; set; }

    public string? Photo { get; set; }
}

