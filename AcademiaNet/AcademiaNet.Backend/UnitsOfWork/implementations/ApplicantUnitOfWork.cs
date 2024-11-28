using AcademiaNet.Backend.Repositories.Implementations;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.DTOs;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;

public class AppliclantUnitOfWork : GenericUnitOfWork<Applicant>, IApplicantUnitOfWork
{
    private readonly IApplicantReposetory _ApplicantUnitOfWork;

    public AppliclantUnitOfWork(IGenericRepository<Applicant> repository, IApplicantReposetory ApplicantUnitOfWork) : base(repository)
    {
        _ApplicantUnitOfWork = ApplicantUnitOfWork;
    }

    public async Task<Applicant> AddApplicantAsync(Applicant applicant) => await _ApplicantUnitOfWork.AddApplicantAsync(applicant);
    public override async Task<ActionResponse<IEnumerable<Applicant>>> GetAsync() => await _ApplicantUnitOfWork.GetAsync();

    public override async Task<ActionResponse<Applicant>> GetAsync(int id) => await _ApplicantUnitOfWork.GetAsync(id);

    public async Task<IEnumerable<Applicant>> GetComboAsync() => await _ApplicantUnitOfWork.GetComboAsync();

}

