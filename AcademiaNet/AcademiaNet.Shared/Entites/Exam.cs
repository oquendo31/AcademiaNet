using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }

        [MaxLength(255)]
        [Required]
        public string Question { get; set; } = null!;

        [Required]
        [Range(1, 100)]
        public int MinValue { get; set; } = 1;

        [Required]
        [Range(1, 100)]
        public int MaxValue { get; set; } = 100;

        //public int PeriodID { get; set; }
        //public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;
        [Required]
        public int EnrollmentPeriodID { get; set; }

        public EnrollmentPeriod? EnrollmentPeriod { get; set; }

        //public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;

        public ICollection<ExamResult>? ExamResults { get; set; }
        public int ExamResultsCount => ExamResults == null ? 0 : ExamResults.Count;
    }
}