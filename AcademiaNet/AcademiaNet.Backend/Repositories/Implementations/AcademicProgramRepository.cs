using AcademiaNet.Backend.Controllers;
using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Fantasy.Backend.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace AcademiaNet.Backend.Repositories.Implementations;

public class AcademicProgramRepository : GenericRepository<AcademicProgram>, IAcademicprogramsRepository
{
    private readonly DataContext _context;
    public AcademicProgramRepository(DataContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<AcademicProgram>> GetComboAsync()
    {
        return await _context.AcademicPrograms
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async override Task<ActionResponse<IEnumerable<AcademicProgram>>> GetAsync()
    {
        var academicprograms = await _context.AcademicPrograms
            .Include(x => x.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<AcademicProgram>>
        {
            WasSuccess = true,
            Result = academicprograms
        };
    }

    public override async Task<ActionResponse<AcademicProgram>> GetAsync(int id)
    {
        var academicprogram = await _context.AcademicPrograms
            .Include(x => x.Name)
            .FirstOrDefaultAsync(x => x.AcademicProgramID == id);
        if (academicprogram == null)
        {
            return new ActionResponse<AcademicProgram>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }
        return new ActionResponse<AcademicProgram>
        {
            WasSuccess = true,
            Result = academicprogram
        };
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