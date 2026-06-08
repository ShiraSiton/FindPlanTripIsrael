using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto.DayTrip;
using Service.Dto.DayTripItem;
using Service.Dto.Rating;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDayTripItemService
    {
        Task<List<DayTripItem>> GetByDayTripIdAsync(int dayTripId);
        Task<DayTripItemDto> GetByIdAsync(int id);
        // הוספת מקום בודד למסלול
        Task<DayTripItemDto> AddItemToDayTripAsync(int dayTripId, DayTripItemToAdd Item);
        // עדכון סדר מקום במסלול
        Task<List<DayTripItemDto>> UpdateOrderInDayTripAsync(int dayTripItemId, int newOrder);
        // מחיקת מקום מהמסלול
        Task<bool> DeleteDayTripItemAsync(int id);
        // החלפת כל המקומות במסלול ברשימת מקומות חדשה
        Task<List<DayTripItemDto>> ReplaceDayTripItemsAsync(int DayTripsId, List<DayTripItemToAdd> Items);
    }
}
