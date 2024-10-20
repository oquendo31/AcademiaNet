﻿using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;

public class ExamResultUnitOfWork : GenericUnitOfWork<Institution>, IInstitutionsUnitOfWork
{
    private readonly IInstitutionsRepository _institutionsRepositories;

    public InstitutionsUnitOfWork(IGenericRepository<Institution> repository, IInstitutionsRepository institutionsRepositories) : base(repository)
    {
        _institutionsRepositories = institutionsRepositories;
    }

    public override async Task<ActionResponse<IEnumerable<Institution>>> GetAsync() => await _institutionsRepositories.GetAsync();

    public override async Task<ActionResponse<Institution>> GetAsync(int id) => await _institutionsRepositories.GetAsync(id);

    public async Task<IEnumerable<Institution>> GetComboAsync() => await _institutionsRepositories.GetComboAsync();
}