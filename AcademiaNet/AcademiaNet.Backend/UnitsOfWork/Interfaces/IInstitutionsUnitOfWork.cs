using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Microsoft.AspNetCore.Identity;

namespace AcademiaNet.Backend.UnitsOfWork.Interfaces;

public interface IInstitutionsUnitOfWork
{
    Task<ActionResponse<Institution>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Institution>>> GetAsync();
    Task<IEnumerable<Institution>> GetComboAsync();

    Task<Institution> AddInstitutionAsync(Institution institution);

}

