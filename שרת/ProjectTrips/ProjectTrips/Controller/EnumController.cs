using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ProjectTrips.Controller
{
    [ApiController]
    [Route("api/enums")]
    public class EnumController : ControllerBase
    {
        private readonly EnumService enumService;

        public EnumController(EnumService enumService)
        {
            this.enumService = enumService;
        }

        [HttpGet("accessibility")]
        public IActionResult GetAccessibilityValues()
        {
            return Ok(enumService.GetAccessibilityValues());
        }

        [HttpGet("difficulty")]
        public IActionResult GetDifficultyValues()
        {
            return Ok(enumService.GetDifficultyValues());
        }

        [HttpGet("travel-mode")]
        public IActionResult GetTravelModeValues()
        {
            return Ok(enumService.GetTravelModeValues());
        }
    }
}
