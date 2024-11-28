using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace AcademiaNet.Backend.Repositories.Implementations;
public class EnrollmentRepository: GenericRepository<Enrollment>, IEnrollmentRepository
{
    private readonly DataContext _context;

    public EnrollmentRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<Enrollment>> GetAsync(int id)
    {
        var enrollment = await _context.Enrollments
            .FirstOrDefaultAsync(x => x.EnrollmentID == id);

        if (enrollment == null)
        {
            return new ActionResponse<Enrollment>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Enrollment>
        {
            WasSuccess = true,
            Result = enrollment,
            Message = "succesful"
        };
    }

    public async Task<IEnumerable<Enrollment>> GetComboAsync()
    {
        return await _context.Enrollments
            .ToListAsync();
    }

    public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
    {
        var entityEntry = await _context.AddAsync(enrollment);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

}
