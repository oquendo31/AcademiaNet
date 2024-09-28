using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AcademicPrograms : GenericController<AcademicProgram>
{
    public AcademicPrograms(IGenericUnitOfWork<AcademicProgram> unitOfWork) : base(unitOfWork)
    {
    }
}

