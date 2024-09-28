using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        [Required]
        public string Document { get; set; } = null!;

        [MaxLength(100)]
        [Required]
        public string Email { get; set; } = null!;

        public Institution Institution { get; set; } = null!;
        public Role Role { get; set; } = null!;

        public int InstitutionID { get; set; }
        public int RoleID { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public int EnrollmentsCount => Enrollments == null ? 0 : Enrollments.Count;
        public ICollection<ExamResult>? ExamResults { get; set; }
        public int ExamResultsCount => ExamResults == null ? 0 : ExamResults.Count;
        public ICollection<Notification>? Notifications { get; set; }
        public int NotificationsCount => Notifications == null ? 0 : Notifications.Count;
    }
}