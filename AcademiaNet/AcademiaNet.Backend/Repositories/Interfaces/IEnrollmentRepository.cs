using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;
public interface IEnrollmentRepository
{
    Task<ActionResponse<Enrollment>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Enrollment>>> GetAsync();
    Task<IEnumerable<Enrollment>> GetComboAsync();
    Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
    Task<bool> EnrollmentExistsAsync(string documentNumber, int academicProgramId);
    Task<bool> ApplicantHasEnrollmentInProgramAsync(string documentNumber, int academicProgramId);
    Task<bool> ApplicantExistsAsync(string documentNumber);
    Task<Applicant?> GetApplicantByDocumentAsync(string documentNumber);


}