using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Azure;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;

[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class AcademicPrograms : GenericController<AcademicProgram>
{
    private readonly IAcademicProgramsUnitOfWorks _AcademicProgramsUnitOfWorks;
    public AcademicPrograms(IGenericUnitOfWork<AcademicProgram> unitOfWork, IAcademicProgramsUnitOfWorks AcademicProgramsUnitOfWorks) : base(unitOfWork)
    {
        _AcademicProgramsUnitOfWorks = AcademicProgramsUnitOfWorks;
}

    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _AcademicProgramsUnitOfWorks.GetComboAsync());
    }

    public override async Task<IActionResult> GetAsync()
    {
        var response = await _AcademicProgramsUnitOfWorks.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }
    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int Id)
    {
        var response = await _AcademicProgramsUnitOfWorks.GetAsync(Id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

    [HttpGet("institution/{institutionId}")]
    public async Task<IActionResult> GetByInstitutionAsync(int institutionId)
    {
        var academicPrograms = await _AcademicProgramsUnitOfWorks.GetByInstitutionAsync(institutionId);

        if (academicPrograms == null || !academicPrograms.Any())
        {
            return NotFound("No academic programs found for the given institution.");
        }

        return Ok(academicPrograms);
    }

}