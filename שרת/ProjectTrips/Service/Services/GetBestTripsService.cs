using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto;
using Service.Dto.DayTrip;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GetBestTripsService : IGetBestTripsService
    {
        private readonly IDayTripRepository repository;
        private readonly IRegionRepository repositoryRegion;
        private readonly IMapper mapper;
        private Dictionary<int, Region> _regionDict;

        public GetBestTripsService(IDayTripRepository repository, IRegionRepository repositoryRegion, IMapper mapper)
        {
            this.repository = repository;
            this.repositoryRegion = repositoryRegion;
            this.mapper = mapper;
        }

        public async Task<List<RecommendedTripDto>> GetBestTripsAsync(TripSearchRequestDto request)
        {
            var trips = await repository.GetFilteredTripsAsync();

            if (_regionDict == null)
            {
                var regions = await repositoryRegion.GetAllAsync();
                _regionDict = regions.ToDictionary(r => r.Id);
            }

            var scoredTrips = trips
                .Select(t => new
                {
                    Trip = t,
                    Score = CalculateScore(t, request),
                    Match = CalculateMatchPercentage(t, request)

                })
                .OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.Trip.NumberOfViews)// Tie-breakers אם יש כמה עם אותו ציון, (נעדיף את הפופולריים יותר) נעשה שבירה
                .ThenBy(x => x.Trip.Id)
                .Take(request.Count)
                .Select(x => new RecommendedTripDto
                {
                    trip = mapper.Map<DayTripDto>(x.Trip),
                    MatchPercentage = x.Match
                })
                .ToList();

            return scoredTrips;
        }

        private int CalculateMatchPercentage(DayTrip trip, TripSearchRequestDto request)
        {
            double score = 0;
            double total = 0;

            // 🎯 אזור
            if (request.RegionId.HasValue && trip.Region != null)
            {
                total += 3;

                int distance = GetDistanceBetweenRegions(trip.Region.Id, request.RegionId.Value);

                if (distance == 0) score += 3;
                else if (distance == 1) score += 2.5;
                else if (distance == 2) score += 2;
                else if (distance <= 4) score += 1;
            }

            // 🎯 סוג טיול
            if (request.TypeId.HasValue)
            {
                total += 2;
                if (trip.TypeId == request.TypeId)
                    score += 2;
            }

            // 🎯 מחיר
            if (request.MaxPrice.HasValue)
            {
                total += 2;

                if (trip.Price <= request.MaxPrice)
                    score += 2;
                else
                {
                    double diff = trip.Price - request.MaxPrice.Value;
                    score += Math.Max(0, 2 - diff / 50); // ירידה הדרגתית
                }
            }

            // 🎯 זמן
            if (request.AvailableHours.HasValue)
            {
                total += 2;

                double diff = Math.Abs(trip.TotalDurationHours - request.AvailableHours.Value);
                score += Math.Max(0, 2 - diff / 2);
            }

            // 🎯 רמת קושי
            if (request.Difficulty.HasValue)
            {
                total += 1.5;

                if (trip.Difficulty == request.Difficulty)
                    score += 1.5;
            }

            // 🎯 נגישות
            if (request.Accessibility.HasValue)
            {
                total += 1.5;

                if (trip.Accessibility == request.Accessibility)
                    score += 1.5;
            }

            // 🎯 מזג אוויר
            if (request.IsRainyDay.HasValue)
            {
                total += 1;

                if (request.IsRainyDay.Value && !trip.AllowRain)
                    score += 0; // לא מתאים בכלל
                else
                    score += 1;
            }

            if (total == 0)
                return 100;

            var percentage = (score / total) * 100;

            return (int)Math.Round(Math.Min(100, Math.Max(0, percentage)));
        }

        private double CalculateScore(DayTrip trip, TripSearchRequestDto request)
        {
            double score = 0;

            score += ScoreRating(trip);// מקסימום 20 נקודות, עם בוסט לאמינות
            score += ScorePrice(trip, request);// מקסימום 20
            score += ScoreDuration(trip, request);// מקסימום 25
            score += ScoreType(trip, request);// 30 נקודות אם מתאים, 0 אם לא
            score += ScorePopularity(trip);// מקסימום 15
            score += ScoreWeather(trip, request);//מקסימום: 10 או מינוס 50 במקרה קיצון
            score += ScoreRegion(trip, request);// מקסימום 40

            if (trip.CreatedAt > DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)))
            {
                score += 5; // חדש = בוסט קטן
            }// חדש +5

            return score;// סה"כ ≈ 245 נקודות המקסימום שאפשר לקבל
        }
        private double ScoreRating(DayTrip trip)
        {
            if (!trip.AverageRating.HasValue) return 0;

            double ratingScore = trip.AverageRating.Value * 20;

            // אמינות
            double confidence = Math.Min(trip.RatingsCount ?? 0, 50) / 50.0;

            return ratingScore * (0.5 + 0.5 * confidence);
        }

        private double ScorePrice(DayTrip trip, TripSearchRequestDto request)
        {
            if (!request.MaxPrice.HasValue) return 0;

            double diff = trip.Price - request.MaxPrice.Value;

            if (diff <= 0)
                return 20; // טוב

            return Math.Max(0, 20 - diff * 2); // יורד בהדרגה
        }

        private double ScoreDuration(DayTrip trip, TripSearchRequestDto request)
        {
            if (!request.AvailableHours.HasValue) return 0;

            double diff = Math.Abs(trip.TotalDurationHours - request.AvailableHours.Value);

            return Math.Max(0, 25 - diff * 5);
        }

        private double ScoreType(DayTrip trip, TripSearchRequestDto request)
        {
            if (!request.TypeId.HasValue) return 0;

            return trip.TypeId == request.TypeId ? 30 : 0;
        }

        private double ScorePopularity(DayTrip trip)
        {
            return Math.Min(trip.NumberOfViews / 100.0, 15);
        }

        private double ScoreWeather(DayTrip trip, TripSearchRequestDto request)
        {
            if (!request.IsRainyDay.HasValue) return 0;

            if (request.IsRainyDay.Value && !trip.AllowRain)
                return -50; // פסילה כמעט מוחלטת

            if (trip.HasCommonWeather)
                return 10;

            return 0;
        }

        //פונקציה שמביאה את כל השרשרת
        private List<int> GetAncestors(int regionId)
        {
            var result = new List<int>();
            var visited = new HashSet<int>();

            if (!_regionDict.ContainsKey(regionId))
                return result;

            var current = _regionDict[regionId];

            while (current != null)
            {
                if (visited.Contains(current.Id))
                    break;
                
                visited.Add(current.Id);
                result.Add(current.Id);

                if (current.ParentRegionId == null)
                    break;

                if (!_regionDict.ContainsKey(current.ParentRegionId.Value))
                    break;

                current = _regionDict[current.ParentRegionId.Value];
            }

            return result;
        }

        //מציאת “מרחק בין אזורים”
        private int GetDistanceBetweenRegions(int regionAId, int regionBId)
        {
            var ancestorsA = GetAncestors(regionAId);
            var ancestorsB = GetAncestors(regionBId);

            for (int i = 0; i < ancestorsA.Count; i++)
            {
                for (int j = 0; j < ancestorsB.Count; j++)
                {
                    if (ancestorsA[i] == ancestorsB[j])
                    {
                        return i + j; // המרחק הכולל
                    }
                }
            }

            return int.MaxValue;
        }

        private double ScoreRegion(DayTrip trip, TripSearchRequestDto request)
        {
            if (!request.RegionId.HasValue || trip.Region == null)
                return 0;

            int distance = GetDistanceBetweenRegions(trip.Region.Id, request.RegionId.Value);

            if (distance == 0)
                return 40; // בדיוק אותו אזור

            if (distance == 1)
                return 35; // ילד / אבא

            if (distance == 2)
                return 30; // אחים (🔥 בני ברק ↔ רמת גן)

            if (distance <= 4)
                return 20; // אזור רחב (גוש דן וכו')

            return 5; // רחוק
        }
    }
}