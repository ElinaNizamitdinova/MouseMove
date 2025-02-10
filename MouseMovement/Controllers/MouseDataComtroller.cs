using Microsoft.AspNetCore.Mvc;
using MouseMovementApp.Application;
using MouseMovementDomain.Domain;

namespace MouseMovement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MouseDataController : ControllerBase
    {
        private readonly MouseMovementService _service;

        public MouseDataController(MouseMovementService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MouseDataDto mouseData)
        {
            if (mouseData == null)
            {
                return BadRequest("Mouse data cannot be null or empty.");
            }

            if (mouseData.Coordinates == null || !mouseData.Coordinates.Any())
            {
                return BadRequest("Mouse data cannot be null or empty.");
            }

            try
            {
                var pointsReceived = await _service.SaveMouseDataAsync(mouseData);
                return Ok(new { PointsReceived = pointsReceived });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
