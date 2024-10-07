using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProHodie.API.Data;
using ProHodie.API.Models;

namespace ProHodie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityCategoriesController : ControllerBase
    {
        private readonly ProHodieDbContext _context;

        public ActivityCategoriesController(ProHodieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityCategory>>> GetActivityCategories()
        {
            return new OkObjectResult(await _context.ActivityCategories.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityCategoryById(int id)
        {
            var activityCategory = await _context.ActivityCategories.SingleOrDefaultAsync(ac => ac.ActivityCategoryId == id);
            if (activityCategory == null)
                return new NotFoundResult();

            return new OkObjectResult(activityCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivityCategory(ActivityCategory activityCategory)
        {
            await _context.ActivityCategories.AddAsync(activityCategory);

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return new OkObjectResult(activityCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivityCategory(ActivityCategory activityCategory, int id)
        {
            var activityCategoryToEdit = await _context.ActivityCategories.SingleOrDefaultAsync(ac => ac.ActivityCategoryId == id);
            if (activityCategoryToEdit == null)
                return BadRequest();

            activityCategoryToEdit.ActivityCategoryName = activityCategory.ActivityCategoryName;

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return new OkObjectResult(id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteActivityCategory(int id)
        {
            var activityCategoryToDelete = await _context.ActivityCategories.SingleOrDefaultAsync(ac => ac.ActivityCategoryId == id);
            if (activityCategoryToDelete == null)
                return BadRequest();

            _context.ActivityCategories.Remove(activityCategoryToDelete);
            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return NoContent();
        }
    }
}
