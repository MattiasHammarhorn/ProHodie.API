using Microsoft.AspNetCore.Mvc;
using ProHodie.API.Models;
using ProHodie.API.Services;

namespace ProHodie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _service;

        public ActivitiesController(IActivityService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities(string? filter)
        {
            return Ok(await _service.GetActivities(filter));
        }

        [HttpGet("filter=ongoing")]
        public async Task<IActionResult> GetOngoingActivity()
        {
            var x = await _service.GetOngoingActivity();
            return Ok(x);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _service.GetActivityById(id);
            if (activity == null)
                return new NotFoundResult();

            return Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] Activity activity)
        {
            await _service.AddActivity(activity);

            return new OkObjectResult(activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity([FromBody] Activity activity, int id)
        {
            if (activity.Id != id)
                return BadRequest();

            await _service.UpdateActivity(activity);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            await _service.DeleteActivity(id);

            return new NoContentResult();
        }
    }
}
