using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.DTOs;
using AcademiaNet.Shared.Responses;
using System.Diagnostics.Metrics;

namespace AcademiaNet.Backend.Repositories.Implementations;

public class ExamResultRepository : GenericRepository<ExamRepository>, IExamResultRepository
{
{
    private readonly DataContext _context;

    public ExamResultRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _context.Countries
        .Include(c => c.Teams)
            .OrderBy(c => c.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Countries
            .Include(x => x.Teams)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Countries.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }

    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await _context.Countries
             .Include(c => c.Teams)
             .FirstOrDefaultAsync(c => c.Id == id);

        if (country == null)
        {
            return new ActionResponse<Country>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = country
        };
    }

    public async Task<IEnumerable<Country>> GetComboAsync()
    {
        return await _context.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}    
}
