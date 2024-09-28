using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstitutionsController : GenericController<Institution>
{
    public InstitutionsController(IGenericUnitOfWork<Institution> unitOfWork) : base(unitOfWork)
    {
    }
}