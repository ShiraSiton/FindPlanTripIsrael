using Microsoft.AspNetCore.Http;
using Repository.Entities;
using Service.Dto.DayTripItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.DayTrip
{
    public class DayTripCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; } //התמונה כמחרוזת
        public IFormFile? FileImage { get; set; }
        public int TypeId { get; set; }
        public TimeOnly StartTime { get; set; }
        public int CreatedByUserId { get; set; }
        public bool SendForApproval { get; set; }
        public List<DayTripItemToAdd> Items { get; set; } = new();
    }
}
