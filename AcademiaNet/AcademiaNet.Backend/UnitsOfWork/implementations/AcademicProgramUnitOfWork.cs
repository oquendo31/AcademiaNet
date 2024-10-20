using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Backend.UnitsOfWork.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.implementations;

public class AcademicProgramUnitOfWork : GenericUnitOfWork<AcademicProgram>, IAcademicProgramUnitOfWorks
{
    private readonly IAcademicprogramsRepository _AcademicprogramRepository;
    public AcademicProgramUnitOfWork(IGenericRepository<AcademicProgram> repository, IAcademicprogramsRepository AcademicprogramsRepository) : base(repository)
    {
        _AcademicprogramRepository = AcademicprogramsRepository;
    }

    public Task<ActionResponse<AcademicProgram>> AddAsync(AcademicProgramDTO academicprogramDTO)
    {
        throw new NotImplementedException();
    }

    public override async Task<ActionResponse<IEnumerable<AcademicProgram>>> GetAsync() => await
        _AcademicprogramRepository.GetAsync();

    public override async Task<ActionResponse<AcademicProgram>> GetAsync(int id) => await _AcademicprogramRepository.GetAsync(id);


    public async Task<IEnumerable<AcademicProgram>> GetComboAsync(int institutionID) => await _AcademicprogramRepository.GetComboAsync();

    public Task<IEnumerable<AcademicProgram>> GetComboAsync()
    {
        throw new NotImplementedException();
    }
}
