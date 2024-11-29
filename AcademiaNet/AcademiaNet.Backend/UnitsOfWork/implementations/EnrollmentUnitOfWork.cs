using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;
public class EnrollmentUnitOfWork: GenericUnitOfWork<Enrollment>, IEnrollmentUnitOfWork
{
    private readonly IEnrollmentRepository _EnrollmentRepository;

    public EnrollmentUnitOfWork(IGenericRepository<Enrollment> repository, IEnrollmentRepository EnrollmentRepository) : base(repository)
    {
        _EnrollmentRepository = EnrollmentRepository;
    }

    public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment) => await _EnrollmentRepository.AddEnrollmentAsync(enrollment);
    public override async Task<ActionResponse<IEnumerable<Enrollment>>> GetAsync() => await _EnrollmentRepository.GetAsync();

    public override async Task<ActionResponse<Enrollment>> GetAsync(int id) => await _EnrollmentRepository.GetAsync(id);

    public async Task<IEnumerable<Enrollment>> GetComboAsync() => await _EnrollmentRepository.GetComboAsync();

    public async Task<bool> EnrollmentExistsAsync(string documentNumber, int academicProgramId)
    {
        return await _EnrollmentRepository.EnrollmentExistsAsync(documentNumber, academicProgramId);
    }

}

