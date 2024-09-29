using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.Entites;
public class Notification
{
    [Key]
    public int NotificationID { get; set; }

    [MaxLength(100)]
    public string AdmissionStatus { get; set; } = null!;

    public DateTime NotificationDate { get; set; }

    [Required]
    public int UserID { get; set; }

    public User User { get; set; } = null!;

    [Required]
    public int EnrollmentPeriodID { get; set; }

    public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;
}
