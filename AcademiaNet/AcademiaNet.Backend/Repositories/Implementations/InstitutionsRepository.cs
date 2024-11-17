﻿using AcademiaNet.Backend.Data;
using AcademiaNet.Backend.Repositories.Interfaces;
using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AcademiaNet.Backend.Repositories.Implementations;

public class InstitutionsRepository : GenericRepository<Institution>, IInstitutionsRepository
{
    private readonly DataContext _context;

    public InstitutionsRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<Institution>> GetAsync(int id)
    {
        var institution = await _context.Institutions
            .FirstOrDefaultAsync(x => x.InstitutionID == id);

        if (institution == null)
        {
            return new ActionResponse<Institution>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Institution>
        {
            WasSuccess = true,
            Result = institution,
            Message = "succesful"
        };
    }

    public override async Task<ActionResponse<IEnumerable<Institution>>> GetAsync()
    {
        var institutions = await _context.Institutions
            .ToListAsync();
        return new ActionResponse<IEnumerable<Institution>>
        {
            WasSuccess = true,
            Result = institutions
        };
    }

    public async Task<IEnumerable<Institution>> GetComboAsync()
    {
        return await _context.Institutions
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Institution> AddInstitutionAsync(Institution institution)
    {
        var entityEntry = await _context.AddAsync(institution);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }
}