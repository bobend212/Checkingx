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

        [HttpGet("checkings")]
        public async Task<ActionResult<List<Checking>>> GetAllCheckings()
        {
            return Ok(await _context.Checking.ToListAsync());
        }

        [HttpGet("checkItems")]
        public async Task<ActionResult<List<CheckItem>>> GetAllCheckItems()
        {
            return Ok(await _context.CheckItems.ToListAsync());
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

        [HttpGet("project/{projectId}/{checkItemId}")]
        public async Task<ActionResult<Checking>> GetAllCheckingsByProjectId(int projectId, int checkItemId)
        {
            var findCheckings = await _context.Checking.Where(x => x.ProjectId == projectId).Include(x => x.Project).Include(x => x.CheckItem).ToListAsync();
            if (findCheckings == null) return NotFound("Checkings not found.");

            var findResult = findCheckings.Where(x => x.CheckItemId == checkItemId);

            return Ok(findResult);
        }

        [HttpGet("show-not-checked-by-project")]
        public async Task<ActionResult<List<CheckItem>>> ShowOnlyCheckingsNotCheckedByProject(int projectId)
        {
            var findProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            var allCheckItems = await _context.CheckItems.ToListAsync();

            var projectCheckItems = await _context.Projects
                .Where(x => x.ProjectId == projectId)
                .SelectMany(x => x.Checking.Select(x => x.CheckItem))
                .ToListAsync();


            var checkItemsNotChecked = allCheckItems.Where(p => !projectCheckItems.Any(p2 => p2.CheckItemId == p.CheckItemId)).ToList();

            //var result = new
            //{ 
            //    Project = findProject.Number,
            //    TotalCheckItems = allCheckItems.Count,
            //    CheckedCheckItems = allCheckItems.Count - (allCheckItems.Count - projectCheckItems.Count),
            //    LeftCheckItems = allCheckItems.Count - projectCheckItems.Count,
            //    CheckItems = checkItemsNotChecked
            //};

            return Ok(checkItemsNotChecked);
        }
    }
}