using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.Entites;

public class Applicant
{
    [Key]
    public int AplicantID { get; set; }

    [Required]
    [MaxLength(100)]
    public string? FullName { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(100)]
    public string? DocumentNumber { get; set; }
}