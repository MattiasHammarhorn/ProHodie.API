using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHodie.API.Data;
using ProHodie.API.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProHodie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ProHodieDbContext _context;

        public ActivitiesController(ProHodieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return Ok(await _context.Activities.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _context.Activities.SingleOrDefaultAsync(a => a.Id == id);
            if (activity == null)
                return new NotFoundResult();

            return Ok(activity);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] Activity activity)
        {
            await _context.AddAsync(activity);

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return Ok(activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity([FromBody] Activity activity, int id)
        {
            var activityToEdit = await _context.Activities.SingleOrDefaultAsync(a => a.Id == id);
            if (activityToEdit == null)
                return BadRequest();

            activityToEdit.Name = activity.Name;
            activityToEdit.ActivityCategoryId = activity.ActivityCategoryId;
            activityToEdit.StartDate = activity.StartDate;
            activityToEdit.EndDate = activity.EndDate;

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromBody] Activity activity, int id)
        {
            var activityToDelete = await _context.Activities.SingleOrDefaultAsync(a => a.Id == id);
            if (activityToDelete == null)
                return BadRequest();

            _context.Remove(activityToDelete);

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return Ok(id);
        }
    }
}
