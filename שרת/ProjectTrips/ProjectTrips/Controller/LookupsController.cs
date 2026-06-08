using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dto;
using Service.Interface;
using Service.Services;

namespace ProjectTrips.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LookupsController : ControllerBase
    {
        private readonly IRegionService serviceRegion;
        private readonly ITypeService serviceType;
        private readonly EnumService enumService;

        public LookupsController(IRegionService serviceRegion, ITypeService serviceType, EnumService enumService)
        {
            this.serviceRegion = serviceRegion;
            this.serviceType = serviceType;
            this.enumService = enumService;
        }

        [HttpGet()]
        public async Task<ActionResult<LookupsDto>> GetLookupsAsync()
        {
            var regions = await serviceRegion.GetAllAsync();
            var types = await serviceType.GetAllDayTripTypesAsync();
            var accessibilities = enumService.GetAccessibilityValues();
            var difficulties = enumService.GetDifficultyValues();

            var result = new LookupsDto
            {
                Accessibilities = accessibilities,
                Difficulties = difficulties,
                Regions = regions,
                TripTypes = types
            };
            return Ok(result);
        }
    }
}