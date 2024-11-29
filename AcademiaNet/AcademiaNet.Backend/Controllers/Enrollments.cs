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
    public async Task<IActionResult> PostEnrollment([FromBody] Enrollment enrollmentRequest)
    {
        // Verificar si el aplicante existe
        if (!await _EnrollmentUnitOfWork.ApplicantExistsAsync(enrollmentRequest.Applicant.DocumentNumber!))
        {
            return NotFound(new { message = "Applicant does not exist." });
        }

        // Verificar si ya tiene una inscripción en el programa
        if (await _EnrollmentUnitOfWork.ApplicantHasEnrollmentInProgramAsync(enrollmentRequest.Applicant.DocumentNumber!, enrollmentRequest.AcademicProgramID))
        {
            return Conflict(new { message = "Enrollment already exists for the given applicant and program." });
        }

        // Obtener el ApplicantId basado en el DocumentNumber
        var applicant = await _EnrollmentUnitOfWork.GetApplicantByDocumentAsync(enrollmentRequest.Applicant.DocumentNumber!);
        if (applicant == null)
        {
            return NotFound(new { message = "Applicant could not be found." });
        }

        // Crear el objeto Enrollment
        var newEnrollment = new Enrollment
        {
            EnrollmentDate = DateTime.UtcNow, // Fecha actual en UTC
            AcademicProgramID = enrollmentRequest.AcademicProgramID, // Del request
            ApplicantId = applicant.AplicantID, // Obtenido del query anterior
        };

        // Insertar el nuevo registro
        var createdEnrollment = await _EnrollmentUnitOfWork.AddEnrollmentAsync(newEnrollment);
        return CreatedAtAction(nameof(GetAsync), new { id = createdEnrollment.EnrollmentID }, createdEnrollment);
    }



}

