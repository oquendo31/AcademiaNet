using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;

public class IExamReusltRepository
{
    Task<ActionResponse<ExamResult>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<ExamResult>>> GetAsync();
    Task<IEnumerable<ExamResult>> GetComboAsync();
}
