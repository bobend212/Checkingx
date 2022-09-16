using Checkingx.Server.Data;
using Checkingx.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingListController : ControllerBase
    {
        private readonly DataContext _context;

        public CheckingListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<CheckItem>> GetAllCheckItems()
        {
            string jsonLocation = $@"{Environment.CurrentDirectory}\Data\checking_list.json";

            List<CheckItem>? checkItems =
                JsonConvert.DeserializeObject<List<CheckItem>>(System.IO.File.ReadAllText(jsonLocation));

            return Ok(checkItems);
        }

        [HttpGet("{id}")]
        public ActionResult<CheckItem> GetSingleCheckItem(int id)
        {
            string jsonLocation = $@"{Environment.CurrentDirectory}\Data\checking_list.json";

            List<CheckItem>? checkItems =
                JsonConvert.DeserializeObject<List<CheckItem>>(System.IO.File.ReadAllText(jsonLocation));

            var findCheckItem = checkItems.FirstOrDefault(x => x.CheckItemId == id);
            if (findCheckItem == null) return NotFound("Check Item not found.");

            return Ok(findCheckItem);
        }

        [HttpPost("check-item-add")]
        public async Task<ActionResult<Checking>> PostChecking(Checking model)
        {
            _context.Checking.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await _context.Checking.FirstOrDefaultAsync(x => x.CheckingId == model.CheckingId));
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<Checking>>> GetAllCheckingsByProjectId(int projectId)
        {
            var findCheckings = await _context.Checking.Where(x => x.ProjectId == projectId).Include(x => x.Project).Include(x => x.CheckItem).ToListAsync();
            if (findCheckings == null) return NotFound("Checkings not found.");

            return Ok(findCheckings);
        }

        [HttpGet("checking/{id}")]
        public async Task<ActionResult<Checking>> GetSingleCheckingById(int id)
        {
            var findChecking = await _context.Checking.Include(x => x.CheckItem).FirstOrDefaultAsync(x => x.CheckingId == id);
            if (findChecking == null) return NotFound("Checking not found.");

            return Ok(findChecking);
        }

        [HttpPut("{id}/correct")]
        public async Task<ActionResult<Checking>> CorrectError(Checking checking, int id)
        {
            var findChecking = await _context.Checking.FirstOrDefaultAsync(x => x.CheckingId == id);
            if (findChecking == null)
                return NotFound("Checking not found.");

            findChecking.IsCorrected = checking.IsCorrected;

            await _context.SaveChangesAsync();

            return Ok(findChecking);
        }
    }
}