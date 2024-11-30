using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.Entites;

public class Enrollment
{
    [Key]
    public int EnrollmentID { get; set; }

    public DateTime EnrollmentDate { get; set; }


    public int AcademicProgramID { get; set; }

    public AcademicProgram AcademicProgram { get; set; } = null!;

    public int ApplicantId { get; set; }

    public Applicant Applicant { get; set; } = null!;
}