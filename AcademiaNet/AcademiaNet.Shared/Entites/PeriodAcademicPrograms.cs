using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaNet.Shared.Entites
{
    public class PeriodAcademicPrograms
    {
        [Key]
        public int PeriodAcademicProgramID { get; set; }

        [Required]
        public int ProgramID { get; set; }

        public AcademicProgram AcademicProgram { get; set; } = null!;

        [Required]
        public int PeriodID { get; set; }

        public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;
    }
}