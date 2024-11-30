using AcademiaNet.Backend.UnitsOfWork.implementations;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
    public async Task<IActionResult> PostEnrollment([FromBody] JsonElement enrollmentRequestJson)
    {
        // Extraer los valores del JSON manualmente
        if (!enrollmentRequestJson.TryGetProperty("documentNumber", out var documentNumberElement) ||
            !enrollmentRequestJson.TryGetProperty("academicProgramID", out var academicProgramIDElement))
        {
            return BadRequest(new { message = "Invalid request body. Ensure 'documentNumber' and 'academicProgramID' are included." });
        }

        var documentNumber = documentNumberElement.GetString();
        var academicProgramID = academicProgramIDElement.GetInt32();

        // Validar si el aplicante existe
        var applicant = await _EnrollmentUnitOfWork.GetApplicantByDocumentAsync(documentNumber!);
        if (applicant == null)
        {
            return NotFound(new { message = "Applicant could not be found." });
        }

        // Verificar si ya tiene una inscripción en el programa
        if (await _EnrollmentUnitOfWork.ApplicantHasEnrollmentInProgramAsync(documentNumber!, academicProgramID))
        {
            return Conflict(new { message = "Enrollment already exists for the given applicant and program." });
        }

        // Crear el objeto Enrollment
        var newEnrollment = new Enrollment
        {
            EnrollmentDate = DateTime.UtcNow, // Fecha actual en UTC
            AcademicProgramID = academicProgramID, // Del request
            ApplicantId = applicant.AplicantID, // Obtenido del query anterior
        };

        // Insertar el nuevo registro
        var createdEnrollment = await _EnrollmentUnitOfWork.AddEnrollmentAsync(newEnrollment);
        return CreatedAtAction(nameof(GetAsync), new { id = createdEnrollment.EnrollmentID }, createdEnrollment);
    }




}

