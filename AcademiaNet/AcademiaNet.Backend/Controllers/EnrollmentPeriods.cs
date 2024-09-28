using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EnrollmentPeriods : GenericController<Enrollment>
{
    public EnrollmentPeriods(IGenericUnitOfWork<Enrollment> unitOfWork) : base(unitOfWork)
    {
    }
}

