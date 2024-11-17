using AcademiaNet.Backend.Repositories.Implementations;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Microsoft.AspNetCore.Identity;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;

public class InstitutionsUnitOfWork : GenericUnitOfWork<Institution>, IInstitutionsUnitOfWork
{
    private readonly IInstitutionsRepository _institutionsRepositories;

    public InstitutionsUnitOfWork(IGenericRepository<Institution> repository, IInstitutionsRepository institutionsRepositories) : base(repository)
    {
        _institutionsRepositories = institutionsRepositories;
    }

    public async Task<Institution> AddInstitutionAsync(Institution user) => await _institutionsRepositories.AddInstitutionAsync(user);
    public override async Task<ActionResponse<IEnumerable<Institution>>> GetAsync() => await _institutionsRepositories.GetAsync();

    public override async Task<ActionResponse<Institution>> GetAsync(int id) => await _institutionsRepositories.GetAsync(id);

    public async Task<IEnumerable<Institution>> GetComboAsync() => await _institutionsRepositories.GetComboAsync();
}

