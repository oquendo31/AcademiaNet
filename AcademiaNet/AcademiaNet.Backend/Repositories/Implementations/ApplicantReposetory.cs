using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace AcademiaNet.Backend.Repositories.Implementations;
public class ApplicantReposetory :GenericRepository<Applicant>, IApplicantReposetory
{
    private readonly DataContext _context;

    public ApplicantReposetory(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<Applicant>> GetAsync(int id)
    {
        var applicant = await _context.Applicant
            .FirstOrDefaultAsync(x => x.AplicantID == id);

        if (applicant == null)
        {
            return new ActionResponse<Applicant>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Applicant>
        {
            WasSuccess = true,
            Result = applicant,
            Message = "succesful"
        };
    }

    public async Task<IEnumerable<Applicant>> GetComboAsync()
    {
        return await _context.Applicant
            .OrderBy(x => x.FullName)
            .ToListAsync();
    }

    public async Task<Applicant> AddApplicantAsync(Applicant applicant)
    {
        var entityEntry = await _context.AddAsync(applicant);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }
}
