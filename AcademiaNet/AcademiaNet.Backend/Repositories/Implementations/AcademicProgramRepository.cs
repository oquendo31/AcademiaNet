using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Fantasy.Backend.Repositories.Implementations;

namespace AcademiaNet.Backend.Repositories.Implementations;

public class AcademicProgramRepository : GenericRepository<AcademicProgram>, IAcademicprogramsRepository
{
    public AcademicProgramRepository(DataContext context) : base(context)
    {
    }

    public override Task<ActionResponse<IEnumerable<AcademicProgram>>> GetAsync()
    {
        return base.GetAsync();
    }

    public override Task<ActionResponse<AcademicProgram>> GetAsync(int id)
    {
        return base.GetAsync(id);
    }

    public Task<ActionResponse<AcademicProgram>> AddAsync(AcademicProgramDTO academicprogramDTO)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AcademicProgram>> GetComboAsync(int institutionID)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResponse<AcademicProgram>> UpdateAsync(AcademicProgramDTO academicprogramDTO)
    {
        throw new NotImplementedException();
    }
}

