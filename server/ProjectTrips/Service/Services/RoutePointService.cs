using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto.RoutePoint;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoutePointService : IRoutePointService
    {
        private readonly IRoutePointRepository repository;
        private readonly IMapper mapper;
        public RoutePointService(IRoutePointRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // 🔹 החזרת כל המקומות במסלול לפי routeId
        public async Task<List<RoutePointDto>> GetByRouteIdAsync(int routeId)
        {
            var points = await repository.GetByRouteIdAsync(routeId);
            return mapper.Map<List<RoutePointDto>>(points);
        }

        public async Task<RoutePointDto> GetByIdAsync(int id) 
        {
            var routePoint = await repository.GetByIdAsync(id);
            if (routePoint == null)
                throw new KeyNotFoundException($"Route point with id {id} not found");

            return mapper.Map<RoutePointDto>(routePoint);
        }

        public async Task<RoutePointDto> UpdateOrderInRouteAsync(int routePointId, int newOrder)
        {
            if (newOrder <= 0)
                throw new ArgumentException("Order must be greater than 0");

            var routePoint = await repository.GetByIdAsync(routePointId);
            if (routePoint == null)
                throw new KeyNotFoundException($"Route point with id {routePointId} not found");

            var routePoints = await repository.GetByRouteIdAsync(routePoint.RouteId);

            int oldOrder = routePoint.OrderInRoute;

            if (newOrder == oldOrder)
                return mapper.Map<RoutePointDto>(routePoint);

            // 🔹 הזזה למטה
            if (newOrder > oldOrder)
            {
                foreach (var rp in routePoints
                    .Where(x => x.OrderInRoute > oldOrder && x.OrderInRoute <= newOrder))
                {
                    rp.OrderInRoute--;
                }
            }
            // 🔹 הזזה למעלה
            else
            {
                foreach (var rp in routePoints
                    .Where(x => x.OrderInRoute >= newOrder && x.OrderInRoute < oldOrder))
                {
                    rp.OrderInRoute++;
                }
            }

            routePoint.OrderInRoute = newOrder;

            await repository.UpdateRangeAsync(routePoints);
            await repository.UpdateAsync(routePoint);

            await FixStartAndEndAsync(routePoint.RouteId);

            return mapper.Map<RoutePointDto>(routePoint);
        }
        private async Task FixStartAndEndAsync(int routeId)
        {
            var points = await repository.GetByRouteIdAsync(routeId);

            if (!points.Any())
                return;

            // קודם מאפסים הכל
            foreach (var p in points)
            {
                p.IsStartPoint = false;
                p.IsEndPoint = false;
            }

            points.First().IsStartPoint = true;
            points.Last().IsEndPoint = true;

            await repository.UpdateRangeAsync(points);
        }

        public async Task<bool> DeleteRoutePointAsync(int id)
        {
            var routePoint = await repository.GetByIdAsync(id);
            if (routePoint == null)
                throw new KeyNotFoundException($"Route point with id {id} not found");

            // אם הכל תקין – מבצעים מחיקה
            await repository.DeleteAsync(id);

            // לאחר המחיקה – לעדכן סדר מחדש
            await ReorderRoutePointsAsync(routePoint.RouteId);

            return true;
        }

        // ----------- פונקציה עזר לסידור מחדש של המקומות ----------------
        private async Task ReorderRoutePointsAsync(int routeId)
        {
            var routePoints = await repository.GetByRouteIdAsync(routeId);

            for (int i = 0; i < routePoints.Count; i++)
            {
                routePoints[i].OrderInRoute = i + 1;
            }

            await repository.UpdateRangeAsync(routePoints);

            await FixStartAndEndAsync(routeId);
        }

        // 💡 פונקציה פרטית להוספת רשימת נקודות למסלול עם סדר
        private async Task AddRoutePointsAsync(int routeId, List<RoutePointCreateDto> points)
        {
            var routePoints = await repository.GetByRouteIdAsync(routeId);
            int order = routePoints.Count() + 1;
            foreach (var point in points)
            {
                var rp = new RoutePoint
                {
                    RouteId = routeId,
                    OrderInRoute = order++,
                    Title = point.Title,
                    Description = point.Description,
                    EstimatedStayMinutes = point.EstimatedStayMinutes,
                    IsStartPoint = point.IsStartPoint,
                    IsEndPoint = point.IsEndPoint
                };
                await repository.AddAsync(rp);
            }
            await FixStartAndEndAsync(routeId);
        }

        // 💡 עדכון מסלול עם רשימת מקומות חדשה (כולל מחיקה של הישנים)
        public async Task<List<RoutePointDto>> ReplaceRoutePointsAsync(int routeId, List<RoutePointCreateDto> pointIds)
        {
            if (pointIds == null || !pointIds.Any())
                throw new InvalidOperationException("No points provided");

            await repository.DeleteByRouteIdAsync(routeId);

            // הכנסת החדשים
            await AddRoutePointsAsync(routeId, pointIds);

            var points = await repository.GetByRouteIdAsync(routeId);
            return mapper.Map<List<RoutePointDto>>(points);
        }

        // 💡 הוספת מקום בודד למסלול
        public async Task<RoutePointDto> AddPointToRouteAsync(int routeId, RoutePointCreateDto point)
        {
            var existingRoute = await GetByRouteIdAsync(routeId);

            var rp = new RoutePoint
            {
                RouteId = routeId,
                OrderInRoute = existingRoute.Count() + 1,
                Title = point.Title,
                Description = point.Description,
                EstimatedStayMinutes = point.EstimatedStayMinutes,
                IsStartPoint = point.IsStartPoint,
                IsEndPoint = point.IsEndPoint
            };

            return mapper.Map<RoutePoint, RoutePointDto>(await repository.AddAsync(rp));
        }
    }
}
