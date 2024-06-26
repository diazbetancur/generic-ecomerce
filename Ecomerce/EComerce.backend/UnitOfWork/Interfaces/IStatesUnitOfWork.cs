﻿using ECommerce.backend.Dto;
using ECommerce.backend.Entities;
using ECommerce.backend.Utils.Responses;

namespace ECommerce.backend.UnitOfWork.Interfaces
{
    public interface IStatesUnitOfWork
    {
        Task<ActionResponse<State>> GetAsync(int Id);
        Task<ActionResponse<IEnumerable<State>>> GetAllAsync();
        Task<ActionResponse<IEnumerable<State>>> GetAllAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPages(PaginationDTO pagination);
    }
}
