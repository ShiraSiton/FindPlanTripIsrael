using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto.Rating;
using Service.Dto.Route;
using Service.Dto.RoutePoint;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRouteService
    {
        // קבלת כל המסלולים
        Task<List<RouteDto>> GetAllAsync();
        // קבלת מסלול בודד לפי Id
        Task<RouteDto> GetByIdAsync(int id);
        // יצירת מסלול חדש
        Task<RouteDto> AddAsync(RouteCreateDto dto);
        // עדכון פרטי מסלול כולל אפשרות לעדכן רשימת מקומות
        Task<RouteDto> UpdateAsync(int userId, int id, RouteUpdateDto dto);
        Task<RouteDto> UpdateRatingAsync(int userId, int id, UpdateRatingDto dto);
        // אישור מסלול 
        Task<RouteDto> SetApprovalStatusAsync(int userId, int id, ApprovalStatus newStatus, string? rejectReason = null);
        // מחיקת מסלול
        Task<bool> DeleteAsync(int userId, int id);
        // הוספת מקום בודד למסלול
        Task<RoutePointDto> AddPointToRouteAsync(int userId, int routeId, RoutePointCreateDto pointId);
        // החלפת כל המקומות במסלול
        Task<List<RoutePointDto>> ReplaceRoutePointsAsync(int userId, int routeId, List<RoutePointCreateDto> newPointIds);
        Task<List<RoutePointDto>> GetRoutePointsAsync(int routeId);
        Task<RoutePointDto> UpdateOrderInRouteAsync(int userId, int routePointId, int newOrder);
        Task<bool> DeleteRoutePointAsync(int userId, int routePointId);
    }
}
