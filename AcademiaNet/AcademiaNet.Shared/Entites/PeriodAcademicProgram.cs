using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class PeriodAcademicProgram
    {
        [Key]
        public int PeriodAcademicProgramID { get; set; }

        [Required]
        public int AcademicProgramID { get; set; }

        public AcademicProgram AcademicProgram { get; set; } = null!;

        [Required]
        public int EnrollmentPeriodID { get; set; }

        public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;
    }
}