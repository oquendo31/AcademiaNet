﻿using System.ComponentModel.DataAnnotations;

namespace AcademiaNet.Shared.Entites;

public class Enrollment
{
    [Key]
    public int EnrollmentID { get; set; }

    [Required]
    public DateTime EnrollmentDate { get; set; }

    [Required]
    public int EnrollmentPeriodID { get; set; }

    public EnrollmentPeriod EnrollmentPeriod { get; set; } = null!;

    [Required]
    public int AcademicProgramID { get; set; }

    public AcademicProgram AcademicProgram { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}