using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Applicants: GenericController<Applicant>
{
    private readonly IApplicantUnitOfWork _ApplicantUnitOfWork;
    public Applicants(IGenericUnitOfWork<Applicant> unitOfWork, IApplicantUnitOfWork ApplicantUnitOfWork) : base(unitOfWork)
    {
        _ApplicantUnitOfWork = ApplicantUnitOfWork;
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int Id)
    {
        var response = await _ApplicantUnitOfWork.GetAsync(Id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

}

