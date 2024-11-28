using AcademiaNet.Shared.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExamenDTO
{
    [Key]
    public int ExamID { get; set; }

    [MaxLength(100)]
    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public int EnrollmentPeriodID { get; set; }

    public ICollection<EnrollmentPeriod>? EnrollmentPeriods { get; set; }

    public int EnrollmentPeriodsCount => EnrollmentPeriods == null ? 0 : EnrollmentPeriods.Count;

    public List<QuestionDTO> Questions { get; set; } = new();
}