using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Dto.Place;
using Service.Dto.Rating;
using Service.Interface;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTrips.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService service;
        public PlaceController(IPlaceService service)
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


        // ==================== POST ====================
        [HttpPost]
        [Authorize] // רק משתמש רשום יכול ליצור מקום
        public async Task<ActionResult<PlaceDto>> CreateAsync([FromBody] PlaceCreateDto dto)
        {
            try
            {
                dto.CreatedByUserId = CurrentUserId;
                var createdPlace = await service.AddAsync(dto);
                return CreatedAtRoute(
                    "GetPlaceById",
                    new { id = createdPlace.Id },
                    createdPlace
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ==================== GET ====================
        [HttpGet]
        [Authorize] // רק למי שיש הרשאה לצפות בטיול
        public async Task<ActionResult<List<PlaceDto>>> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }


        [HttpGet("{id}", Name = "GetPlaceById")]
        [AllowAnonymous] // כולם יכולים לראות מקום ספציפי, גם ללא הרשמה אם מדובר בטיול מוכן
        public async Task<ActionResult<PlaceDto>> GetByIdAsync(int id)
        {
            try
            {
                return Ok(await service.GetByIdAsync(id));
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Place with id {id} not found.");
            }
        }

        // ==================== PUT ====================
        [HttpPut("{id}")]
        [Authorize] // עדכון – רק יוצר המקום או מנהל
        public async Task<IActionResult> UpdateProfilePlaceAsync(int id, [FromBody] UpdateProfilePlaceDto dto)
        {
            try
            {
                await service.UpdateProfilePlaceAsync(CurrentUserId, id, dto);
                return Ok("Place updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Place with id {id} not found.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/rating")]
        [Authorize] // עדכון דירוג – רק משתמש רשום
        public async Task<IActionResult> UpdateRatingAsync(int id, [FromBody] UpdateRatingDto dto)
        {
            try
            {
                await service.UpdateRatingAsync(CurrentUserId, id, dto);
                return Ok("Place updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Place with id {id} not found.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/approval")]
        [Authorize] // אישור מקום – רק מנהל
        public async Task<IActionResult> SetApprovalAsync(int id, [FromQuery] ApprovalStatus approvalStatus, string? rejectReason)
        {
            try
            {
                await service.SetApprovalStatusAsync(CurrentUserId, id, approvalStatus, rejectReason);
                return Ok("Place updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Place with id {id} not found.");
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


        // ==================== DELETE ====================
        [HttpDelete("{id}")]
        [Authorize] // מחיקה – רק יוצר המקום או מנהל
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await service.DeleteAsync(CurrentUserId, id);
                return Ok(new { message = "Place type deactivated successfully" });
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
            catch (Exception)
            {
                return StatusCode(500, "Unexpected error");
            }
        }
    }
}