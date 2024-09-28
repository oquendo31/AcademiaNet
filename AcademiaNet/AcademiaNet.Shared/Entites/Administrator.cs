using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AcademiaNet.Shared.Entites;

public class Administrator
{
    [Key]
    public int AdministradorID { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    [Required]
    public string email { get; set; } = null!;

    [MaxLength(100)]
    public string? Description { get; set; } // Permitir null
}