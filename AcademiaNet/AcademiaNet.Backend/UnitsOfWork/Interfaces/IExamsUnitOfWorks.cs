﻿using AcademiaNet.Shared.Entites;
using AcademiaNet.Shared.Responses;

namespace AcademiaNet.Backend.UnitsOfWork.Interfaces;

public interface IExamsUnitOfWorks
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="examenDTO"></param>
    /// <returns></returns>
    Task<ActionResponse<Exam>> AddAsync(ExamenDTO examDto);

    ///// <summary>
    /////
    ///// </summary>
    ///// <returns></returns>
    //Task<ActionResponse<IEnumerable<Exam>>> GetAllAsync();

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ActionResponse<Exam>> GetAsync(int id);

    ///// <summary>
    /////
    ///// </summary>
    ///// <param name="id"></param>
    ///// <param name="examDto"></param>
    ///// <returns></returns>
    //Task<ActionResponse<bool>> UpdateAsync(int id, ExamenDTO examDto);

    ///// <summary>
    /////
    ///// </summary>
    ///// <param name="id"></param>
    ///// <returns></returns>
    //Task<ActionResponse<bool>> DeleteAsync(int id);
}