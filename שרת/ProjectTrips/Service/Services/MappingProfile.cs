using AutoMapper;
using Repository.Entities;
using Service.Dto;
using Service.Dto.DayTrip;
using Service.Dto.DayTripItem;
using Service.Dto.Image;
using Service.Dto.Place;
using Service.Dto.Region;
using Service.Dto.Review;
using Service.Dto.Route;
using Service.Dto.RoutePoint;
using Service.Dto.Type;
using Service.Dto.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MappingProfile : Profile
    {
        string path = Directory.GetCurrentDirectory() + "\\Images\\";
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<RegionDto, Region>();
            CreateMap<Region, RegionDto>();
            CreateMap<RegionCreateUpdateDto, Region>();

            CreateMap<PlaceDto, Place>();
            CreateMap<Place, PlaceDto>().ForMember(dest => dest.Accessibility,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.Accessibility,
                        Name = TranslateAccessibility(src.Accessibility)
                    }))
                .ForMember(dest => dest.ApprovalStatus,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.ApprovalStatus,
                        Name = TranslateApprovalStatus(src.ApprovalStatus)
                    }))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Region,
                    opt => opt.MapFrom(src => src.Region));
            CreateMap<PlaceCreateDto, Place>();

            CreateMap<Image, ImageDto>().ForMember("Image", x => x.MapFrom(y => fromStringToByte(y.ImageUrl)));
            CreateMap<ImageCreateDto, Image>().ForMember("ImageUrl", x => x.MapFrom(y => y.FileImage.FileName));

            CreateMap<RouteCreateDto, Route>();
            CreateMap<Route, RouteDto>()
                .ForMember(dest => dest.Accessibility,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.Accessibility,
                        Name = TranslateAccessibility(src.Accessibility)
                    }))
                .ForMember(dest => dest.Difficulty,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.Difficulty,
                        Name = TranslateDifficulty(src.Difficulty)
                    }))
                .ForMember(dest => dest.ApprovalStatus,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.ApprovalStatus,
                        Name = TranslateApprovalStatus(src.ApprovalStatus)
                    }))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Region,
                    opt => opt.MapFrom(src => src.Region));
            CreateMap<Route, RouteCreateDto>();

            CreateMap<RoutePointDto, RoutePoint>();
            CreateMap<RoutePoint, RoutePointDto>();

            CreateMap<DayTripDto, DayTrip>();
            CreateMap<DayTrip, DayTripDto>()
                .ForMember("Image", 
                    x => x.MapFrom(y => fromStringToByte(y.ImageUrl)))
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Accessibility,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.Accessibility,
                        Name = TranslateAccessibility(src.Accessibility)
                    }))
                .ForMember(dest => dest.Difficulty,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.Difficulty,
                        Name = TranslateDifficulty(src.Difficulty)
                    }))
                .ForMember(dest => dest.ApprovalStatus,
                    opt => opt.MapFrom(src => new EnumValueDto
                    {
                        Id = (int)src.ApprovalStatus,
                        Name = TranslateApprovalStatus(src.ApprovalStatus)
                    }))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Region,
                    opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.StopsCount,
                    opt => opt.MapFrom(src => src.DayTripItems != null ?
                    src.DayTripItems.Count : 0))
                .ForMember(dest => dest.ReviewsCount,
                    opt => opt.MapFrom(src => src.Reviews != null ?
                    src.Reviews.Count : 0));
            CreateMap<DayTripCreateDto, DayTrip>().ForMember("ImageUrl", x => x.MapFrom(y => y.FileImage.FileName));


            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewCreateDto, Review>();

            CreateMap<TypeDto, Repository.Entities.Type>();
            CreateMap<Repository.Entities.Type, TypeDto>();
            CreateMap<TypeCreateUpdateDto, Repository.Entities.Type>();

            CreateMap<DayTripItemDto, DayTripItem>();
            CreateMap<DayTripItem, DayTripItemDto>();
            CreateMap<DayTripItemCreateDto, DayTripItem>();
        }
        //public byte[] fromStringToByte(string mypath)
        //{
        //    return File.ReadAllBytes(path + mypath);
        //}
        public byte[] fromStringToByte(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Images",
                fileName
            );

            if (!File.Exists(path))
                return null;

            return File.ReadAllBytes(path);
        }
        private string TranslateAccessibility(Accessibility value)
        {
            return value switch
            {
                Accessibility.NotAccessible => "לא נגיש",
                Accessibility.Low => "נגישות נמוכה",
                Accessibility.Partial => "נגיש חלקית",
                Accessibility.WheelchairAccessible => "נגיש לכיסאות גלגלים",
                Accessibility.FullyAccessible => "נגישות מלאה",
                _ => value.ToString()
            };
        }

        private string TranslateDifficulty(Difficulty value)
        {
            return value switch
            {
                Difficulty.Easy => "קל",
                Difficulty.EasyMedium => "קל-בינוני",
                Difficulty.Medium => "בינוני",
                Difficulty.MediumHard => "בינוני-קשה",
                Difficulty.Hard => "קשה",
                _ => value.ToString()
            };
        }

        private string TranslateTravelMode(TravelMode value)
        {
            return value switch
            {
                TravelMode.Walking => "הליכה",
                TravelMode.Car => "רכב",
                TravelMode.Bike => "אופניים",
                _ => value.ToString()
            };
        }

        private string TranslateApprovalStatus(ApprovalStatus value)
        {
            return value switch
            {
                ApprovalStatus.Draft => "טיוטה",
                ApprovalStatus.Pending => "מחכה לאישור",
                ApprovalStatus.Approved => "מאושר",
                ApprovalStatus.Rejected => "נדחה",
                _ => value.ToString()
            };
        }
    }
}

