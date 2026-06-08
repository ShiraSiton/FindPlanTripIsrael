using Repository.Entities;
using Service.Dto.RoutePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoutePointService
    {
        Task<List<RoutePointDto>> GetByRouteIdAsync(int routeId);
        Task<RoutePointDto> GetByIdAsync(int id);
        // הוספת מקום בודד למסלול
        Task<RoutePointDto> AddPointToRouteAsync(int routeId, RoutePointCreateDto placeId);
        // עדכון סדר מקום במסלול
        Task<RoutePointDto> UpdateOrderInRouteAsync(int routePlaceId, int newOrder);
        // מחיקת מקום מהמסלול
        Task<bool> DeleteRoutePointAsync(int id);
        // החלפת כל המקומות במסלול ברשימת מקומות חדשה
        Task<List<RoutePointDto>> ReplaceRoutePointsAsync(int routeId, List<RoutePointCreateDto> placeIds);
    }
}
