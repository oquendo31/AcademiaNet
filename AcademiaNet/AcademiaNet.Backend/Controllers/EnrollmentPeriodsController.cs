﻿using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Fantasy.Backend.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaNet.Backend.Controllers;

//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]
public class EnrollmentPeriodsController : GenericController<EnrollmentPeriod>
{
    public EnrollmentPeriodsController(IGenericUnitOfWork<EnrollmentPeriod> unitOfWork) : base(unitOfWork)
    {
    }
}


