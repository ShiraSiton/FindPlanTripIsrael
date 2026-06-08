using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dto.Rating;
using Service.Dto.Route;
using Service.Dto.RoutePoint;
using Service.Interface;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTrips.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService service;
        public RouteController(IRouteService service)
        {
            this.service = service;
        }

        // ===== Helper =====
        private int CurrentUserId
        {
            get
            {
                var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(claim, out var id))
                    throw new UnauthorizedAccessException("User ID claim missing or invalid.");
                return id;
            }
        }

        // ================= ROUTE =================

        // יצירת מסלול – דורש משתמש רשום
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RouteDto>> CreateAsync([FromBody] RouteCreateDto dto)
        {
            try
            {
                dto.CreatedByUserId = CurrentUserId;
                var createdRoute = await service.AddAsync(dto);
                return CreatedAtRoute(
                    "GetRouteById",
                    new { id = createdRoute.Id },
                    createdRoute
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // קבלת כל המסלולים – דורש משתמש רשום
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RouteDto>>> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }

        // קבלת מסלול לפי מזהה – פתוח לכולם
        [HttpGet("{id}", Name = "GetRouteById")]
        [AllowAnonymous]
        public async Task<ActionResult<RouteDto>> GetByIdAsync(int id)
        {
            try
            {
                return Ok(await service.GetByIdAsync(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Route with id {id} not found.");
            }
        }

        // עדכון מסלול – דורש משתמש רשום
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RouteUpdateDto dto)
        {
            try
            {
                await service.UpdateAsync(CurrentUserId, id, dto);
                return Ok("Route updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Route with id {id} not found.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // עדכון דירוג מסלול – דורש משתמש רשום
        [HttpPut("{id}/rating")]
        [Authorize]
        public async Task<IActionResult> UpdateRatingAsync(int id, [FromBody] UpdateRatingDto dto)
        {
            try
            {
                await service.UpdateRatingAsync(CurrentUserId, id, dto);
                return Ok("Route updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Route with id {id} not found.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // אישור מסלול – מנהל בלבד
        [HttpPut("{id}/approval")]
        [Authorize]
        public async Task<IActionResult> SetApprovalAsync(int id, [FromQuery] ApprovalStatus approvalStatus, string? rejectReason)
        {
            try
            {
                await service.SetApprovalStatusAsync(CurrentUserId, id, approvalStatus, rejectReason);
                return Ok("Route updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Route with id {id} not found.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // מחיקת מסלול – דורש משתמש רשום
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await service.DeleteAsync(CurrentUserId, id);
                return Ok(new { message = "Route type deactivated successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ================= ROUTE POINTS =================

        // קבלת נקודות מסלול – פתוח לכולם
        [HttpGet("{routeId}/points")]
        [AllowAnonymous]
        public async Task<ActionResult<List<RoutePointDto>>> GetRoutePointsAsync(int routeId)
        {
            try
            {
                return Ok(await service.GetRoutePointsAsync(routeId));
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Route not found.");
            }
        }

        // הוספת נקודה למסלול – דורש משתמש רשום
        [HttpPost("{routeId}/points")]
        [Authorize]
        public async Task<IActionResult> AddPointToRouteAsync(int routeId, [FromBody] RoutePointCreateDto point)
        {
            try
            {
                var result = await service.AddPointToRouteAsync(CurrentUserId, routeId, point);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // עדכון סדר נקודה – דורש משתמש רשום
        [HttpPut("points/{routePointId}/order")]
        [Authorize]
        public async Task<IActionResult> UpdateOrderAsync(int routePointId, [FromQuery] int newOrder)
        {
            try
            {
                await service.UpdateOrderInRouteAsync(CurrentUserId, routePointId, newOrder);
                return Ok("Order updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // מחיקת נקודה – דורש משתמש רשום
        [HttpDelete("points/{routePointId}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoutePointAsync(int routePointId)
        {
            try
            {
               await service.DeleteRoutePointAsync(CurrentUserId, routePointId);
                return Ok("Point removed from route.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // החלפת כל נקודות – דורש משתמש רשום
        [HttpPut("{routeId}/points")]
        [Authorize]
        public async Task<IActionResult> ReplaceRoutePointsAsync(int routeId, [FromBody] List<RoutePointCreateDto> points)
        {
            try
            {
                await service.ReplaceRoutePointsAsync(CurrentUserId, routeId, points);
                return Ok("Route points replaced successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}