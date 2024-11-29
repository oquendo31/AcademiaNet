using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.Interfaces;
public interface IEnrollmentUnitOfWork
{
    Task<ActionResponse<Enrollment>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Enrollment>>> GetAsync();
    Task<IEnumerable<Enrollment>> GetComboAsync();
    Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
    Task<bool> EnrollmentExistsAsync(string documentNumber, int academicProgramId);

}

