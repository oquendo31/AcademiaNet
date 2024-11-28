using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;

public interface IAcademicprogramsRepository
{
    Task<IEnumerable<AcademicProgram>> GetComboAsync();
    Task<ActionResponse<AcademicProgram>> AddAsync(AcademicProgramDTO academicprogramDTO);
    Task<ActionResponse<AcademicProgram>> UpdateAsync(AcademicProgramDTO academicprogramDTO);
    Task<ActionResponse<AcademicProgram>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<AcademicProgram>>> GetAsync();

    Task<IEnumerable<AcademicProgram>> GetByInstitutionAsync(int institutionID);

}

