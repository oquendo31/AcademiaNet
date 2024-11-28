using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;

public class ExamsUnitOfWork : GenericUnitOfWork<Exam>, IExamsUnitOfWorks
{
    private readonly IExamsRepository _ExamsRepository;

    public ExamsUnitOfWork(IGenericRepository<Exam> repository, IExamsRepository ExamsRepository) : base(repository)
    {
        _ExamsRepository = ExamsRepository;
    }

    ///// <summary>
    ///// Get All Async
    ///// </summary>
    ///// <returns></returns>

    //public override async Task<ActionResponse<IEnumerable<Exam>>> GetAllAsync() => await _ExamsRepository.GetAllAsync();

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ///
    public override async Task<ActionResponse<Exam>> GetAsync(int id) => await _ExamsRepository.GetAsync(id);

  

    public Task<IEnumerable<Exam>> GetComboAsync()
    {
        throw new NotImplementedException();
    }

    //public Task<ActionResponse<bool>> UpdateAsync(int id, ExamenDTO examDto)
    //{
    //    throw new NotImplementedException();
    //}

    async Task<ActionResponse<Exam>> IExamsUnitOfWorks.AddAsync(ExamenDTO examenDTO)
    {
        var response = await _ExamsRepository.AddAsync(examenDTO);

        if (!response.WasSuccess)
        {
            return response;
        }
        //await SaveChangesAsync();
        return response;
    }

    //Task<ActionResponse<bool>> IExamsUnitOfWorks.DeleteAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}
}