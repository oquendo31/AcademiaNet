using AcademiaNet.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.Entites;

public class Institution
{
    [Key]
    public int InstitutionID { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string? Location { get; set; } // Permitir null

    [MaxLength(100)]
    public string? Description { get; set; } // Permitir null

    [Display(Name = "Image", ResourceType = typeof(Literals))]
    public string? Photo { get; set; }

    public ICollection<User>? Users { get; set; }
    public int UsersCount => Users == null ? 0 : Users.Count;

}