﻿using AcademiaNet.Backend.UnitsOfWork.implementations;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstitutionsController : GenericController<Institution>
{
    private readonly IInstitutionsUnitOfWork _institutionsUnitOfWork;
    public InstitutionsController(IGenericUnitOfWork<Institution> unitOfWork, IInstitutionsUnitOfWork institutionsUnitOfWork) : base(unitOfWork)
    {
        _institutionsUnitOfWork = institutionsUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var response = await _institutionsUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _institutionsUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _institutionsUnitOfWork.GetComboAsync());
    }


}