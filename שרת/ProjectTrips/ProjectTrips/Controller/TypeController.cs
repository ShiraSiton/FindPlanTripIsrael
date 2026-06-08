using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Dto.Type;
using Service.Interface;
using System.Security.Claims;

namespace ProjectTrips.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService service;

        public TypeController(ITypeService service)
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

        [HttpPost]
        public async Task<ActionResult<TypeDto>> CreateAsync(TypeCreateUpdateDto type)
        {
            var created = await service.CreateTypeAsync(type);
            return CreatedAtRoute(
                "GetTypeById",
                new { id = created.Id },
                created
            );
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeDto>>> GetAllAsync()
        {
            var types = await service.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("{id}", Name = "GetTypeById")]
        public async Task<ActionResult<TypeDto>> GetByIdAsync(int id)
        {
            var type = await service.GetTypeByIdAsync(id);
            if (type == null) 
                return NotFound();
            return Ok(type);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<TypeDto>> UpdateAsync(int id, TypeCreateUpdateDto type)
        {
            var updated = await service.UpdateTypeAsync(CurrentUserId, id, type);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await service.DeleteTypeAsync(CurrentUserId, id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
