using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;

public class IExamRepository
{
    Task<ActionResponse<Exam>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Exam>>> GetAsync();
    Task<IEnumerable<Exam>> GetComboAsync();
}
