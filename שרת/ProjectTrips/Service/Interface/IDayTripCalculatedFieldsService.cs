using Repository.Entities;
using Service.Dto.DayTrip;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDayTripCalculatedFieldsService
    {
        Task<ComputedDayTripFields> CalculateComputedFieldsAsync(DayTrip dayTrip);
    }
}
