using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto.Place;
using Service.Dto.Rating;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPlaceService
    {
        Task<PlaceDto> AddAsync(PlaceCreateDto dto);
        Task<List<PlaceDto>> GetAllAsync();
        Task<PlaceDto> GetByIdAsync(int id);
        Task<PlaceDto> UpdateProfilePlaceAsync(int userId, int id, UpdateProfilePlaceDto dto);
        Task<PlaceDto> UpdateRatingAsync(int userId, int id, UpdateRatingDto dto);
        Task<PlaceDto> SetApprovalStatusAsync(int userId, int id, ApprovalStatus newStatus, string? rejectReason = null);
        Task<bool> DeleteAsync(int userId, int id);
    }
}
