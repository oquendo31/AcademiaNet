using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExamsController : GenericController<Exam>
{
    public ExamsController(IGenericUnitOfWork<Exam> unitOfWork) : base(unitOfWork)
    {
    }
}

