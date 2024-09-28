using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstitutionsController : GenericController<Institution>
{
    public InstitutionsController(IGenericUnitOfWork<Institution> unitOfWork) : base(unitOfWork)
    {
    }
}