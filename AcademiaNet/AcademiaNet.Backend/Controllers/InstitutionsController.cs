using AcademiaNet.Backend.Helpers;
using AcademiaNet.Backend.UnitsOfWork.implementations;
using AcademiaNet.Backend.UnitsOfWork.Implementations;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.DTOs;
using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fantasy.Backend.Controllers;

[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class InstitutionsController : GenericController<Institution>
{
    private readonly IInstitutionsUnitOfWork _institutionsUnitOfWork;
    private readonly IFileStorage _fileStorage;

    public InstitutionsController(IGenericUnitOfWork<Institution> unitOfWork, IInstitutionsUnitOfWork institutionsUnitOfWork, IFileStorage fileStorage) : base(unitOfWork)
    {
        _institutionsUnitOfWork = institutionsUnitOfWork;
        _fileStorage = fileStorage;
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

    [AllowAnonymous]
    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _institutionsUnitOfWork.GetComboAsync());
    }

    [HttpPost("CreateInstitution")]
    public async Task<IActionResult> CreateInstitution([FromBody] InstitutionDTO model)
    {
        if(!string.IsNullOrEmpty(model.Photo))
        {
            var base64Data = model.Photo.Substring(model.Photo.IndexOf(',') + 1);
            var photoInstitution = Convert.FromBase64String(base64Data);
            model.Photo = await _fileStorage.SaveFileAsync(photoInstitution, ".jpg", "insitituions");
        }

        //var result = await _institutionsUnitOfWork.AddInstitutionAsync(model);
        

        //return BadRequest(result.Errors.FirstOrDefault());
        return BadRequest();
    }
}