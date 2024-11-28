using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;

public interface IExamsRepository
{
    Task<IEnumerable<Exam>> GetComboAsync();

    Task<ActionResponse<Exam>> AddAsync(ExamenDTO examenDTO);

    //Task<ActionResponse<Exam>> UpdateAsync(ExamenDTO examenDTO);

    Task<ActionResponse<Exam>> GetAsync(int id);

    //Task<ActionResponse<IEnumerable<Exam>>> GetAllAsync();
}