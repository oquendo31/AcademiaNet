using AcademiaNet.Shared.Enums;
using AcademiaNet.Shared.Resources;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.Entites;

public class User : IdentityUser
{
    //[Key]
    //public int UserID { get; set; }

    [Display(Name = "FirstName", ResourceType = typeof(Literals))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName", ResourceType = typeof(Literals))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string LastName { get; set; } = null!;

    [Display(Name = "Image", ResourceType = typeof(Literals))]
    public string? Photo { get; set; }

    [Display(Name = "UserType", ResourceType = typeof(Literals))]
    public UserType UserType { get; set; }

    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public Institution Institution { get; set; } = null!;

    public int InstitutionID { get; set; }

    //public Role Role { get; set; } = null!;

    //public int RoleID { get; set; }

    public ICollection<ExamResult>? ExamResults { get; set; }
    public int ExamResultCount => ExamResults == null ? 0 : ExamResults.Count;

    public ICollection<Enrollment>? Enrollments { get; set; }
    public int EnrollmentCount => Enrollments == null ? 0 : Enrollments.Count;

    public ICollection<Notification>? Notifications { get; set; }
    public int NotificationCount => Notifications == null ? 0 : Notifications.Count;

    [Display(Name = "User", ResourceType = typeof(Literals))]
    public string FullName => $"{FirstName} {LastName}";
}