﻿using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.Repositories.Interfaces;
public interface IApplicantReposetory
{
    Task<ActionResponse<Applicant>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Applicant>>> GetAsync();
    Task<IEnumerable<Applicant>> GetComboAsync();
    Task<Applicant> AddApplicantAsync(Applicant applicant);

}



