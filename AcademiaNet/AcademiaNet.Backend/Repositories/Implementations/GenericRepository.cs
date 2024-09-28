using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace AcademiaNet.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;
    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity = context.Set<T>();

    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    private ActionResponse<T> ExceptionActionResponse(Exception exception)
    {
        return new ActionResponse<T>
        {
            WasSuccess = false,
            Message = exception.Message
        };
    }

    private ActionResponse<T> DbUpdateExceptionActionResponse()
    {
        return new ActionResponse<T>
        {
            WasSuccess = false,
            Message = "ERR003"
        };
    }
}

