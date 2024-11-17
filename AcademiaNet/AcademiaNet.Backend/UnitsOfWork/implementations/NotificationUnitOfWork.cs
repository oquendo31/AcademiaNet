using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Microsoft.AspNetCore.Identity;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;

public class NotificationUnitOfWork : GenericUnitOfWork<Institution>, IInstitutionsUnitOfWork
{
    private readonly IInstitutionsRepository _institutionsRepositories;

    public NotificationUnitOfWork(IGenericRepository<Institution> repository, IInstitutionsRepository institutionsRepositories) : base(repository)
    {
        _institutionsRepositories = institutionsRepositories;
    }

    public Task<IdentityResult> AddInstitutionAsync(Institution institution)
    {
        throw new NotImplementedException();
    }

    public override async Task<ActionResponse<IEnumerable<Institution>>> GetAsync() => await _institutionsRepositories.GetAsync();

    public override async Task<ActionResponse<Institution>> GetAsync(int id) => await _institutionsRepositories.GetAsync(id);

    public async Task<IEnumerable<Institution>> GetComboAsync() => await _institutionsRepositories.GetComboAsync();

    Task<Institution> IInstitutionsUnitOfWork.AddInstitutionAsync(Institution institution)
    {
        throw new NotImplementedException();
    }
}