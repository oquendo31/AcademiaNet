using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;

public interface IInstitutionsRepository
{
    Task<ActionResponse<Institution>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Institution>>> GetAsync();
    Task<IEnumerable<Institution>> GetComboAsync();

}

