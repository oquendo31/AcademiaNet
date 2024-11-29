using AcademiaNet.Backend.UnitsOfWork.implementations;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Enrollments: GenericController<Enrollment>
{
    private readonly IEnrollmentUnitOfWork _EnrollmentUnitOfWork;
    public Enrollments(IGenericUnitOfWork<Enrollment> unitOfWork, IEnrollmentUnitOfWork EnrollmentUnitOfWork) : base(unitOfWork)
    {
        _EnrollmentUnitOfWork = EnrollmentUnitOfWork;
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int Id)
    {
        var response = await _EnrollmentUnitOfWork.GetAsync(Id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

    [HttpPost("validate")]
    public async Task<IActionResult> PostEnrollment([FromBody] Enrollment enrollment)
    {
        if (await _EnrollmentUnitOfWork.EnrollmentExistsAsync(enrollment.Applicant.DocumentNumber!, enrollment.AcademicProgramID))
        {
            return Conflict(new { message = "Enrollment already exists for the given applicant document and program." });
        }

        var createdEnrollment = await _EnrollmentUnitOfWork.AddEnrollmentAsync(enrollment);
        return CreatedAtAction(nameof(GetAsync), new { id = createdEnrollment.EnrollmentID }, createdEnrollment);
    }

}

