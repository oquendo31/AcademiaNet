using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int PeriodID { get; set; }

        [Required]
        public int ProgramID { get; set; }

        public User User { get; set; } = null!;
        public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;
        public AcademicProgram AcademicProgram { get; set; } = null!;
    }
}