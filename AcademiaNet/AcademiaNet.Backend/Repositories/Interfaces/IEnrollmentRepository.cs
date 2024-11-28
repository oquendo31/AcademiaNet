using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;
public interface IEnrollmentRepository
{
    Task<ActionResponse<Enrollment>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Enrollment>>> GetAsync();
    Task<IEnumerable<Enrollment>> GetComboAsync();
    Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
}