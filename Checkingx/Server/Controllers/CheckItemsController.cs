using AutoMapper;
using Checkingx.Server.Data;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckItemsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CheckItemsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Return all check items.")]
        [HttpGet("all")]
        public async Task<ActionResult<List<CheckItem>>> GetAllCheckItems()
        {
            return Ok(await _context.CheckItems.ToListAsync());
        }

        [SwaggerOperation(Summary = "Return all check items for specified category.")]
        [HttpGet("all/{category}")]
        public async Task<ActionResult<List<CheckItem>>> GetAllCheckItemsByCategory(string category)
        {
            return Ok(await _context.CheckItems.Where(x => x.Category.ToUpper() == category.ToUpper()).ToListAsync());
        }

        [SwaggerOperation(Summary = "Return single CheckItem entry by CheckItemId.")]
        [HttpGet("single/{checkItemId}")]
        public async Task<ActionResult<CheckItem>> GetSingleCheckItem(int checkItemId)
        {
            var findCheckItem = await _context.CheckItems.FirstOrDefaultAsync(x => x.CheckItemId == checkItemId);
            if (findCheckItem == null) return NotFound("Check Item not found.");

            return Ok(findCheckItem);
        }

        [SwaggerOperation(Summary = "Return all CheckItems NOT CHECKED by projectId.")]
        [HttpGet("project/{projectId}/not-checked")]
        public async Task<ActionResult<List<CheckItem>>> ShowOnlyCheckingsNotCheckedByProject(int projectId)
        {
            var findProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (findProject == null) return NotFound("Project not found.");

            var allCheckItems = await _context.CheckItems.ToListAsync();

            var projectCheckItems = await _context.Projects
                .Where(x => x.ProjectId == projectId)
                .SelectMany(x => x.Checking.Select(x => x.CheckItem))
                .ToListAsync();

            var checkItemsNotChecked = allCheckItems.Where(p => !projectCheckItems.Any(p2 => p2.CheckItemId == p.CheckItemId)).ToList();

            //var resultExtended = new
            //{
            //    Project = findProject.Number,
            //    TotalCheckItems = allCheckItems.Count,
            //    CheckedCheckItems = allCheckItems.Count - (allCheckItems.Count - projectCheckItems.Count),
            //    LeftCheckItems = allCheckItems.Count - projectCheckItems.Count,
            //    CheckItems = checkItemsNotChecked
            //};

            return Ok(checkItemsNotChecked);
        }

        [SwaggerOperation(Summary = "Return all CheckItems CHECKED by projectId.")]
        [HttpGet("project/{projectId}/checked")]
        public async Task<ActionResult<List<CheckItem>>> ShowOnlyCheckingsCheckedByProject(int projectId)
        {
            var findProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (findProject == null) return NotFound("Project not found.");

            var projectCheckItems = await _context.Projects
                .Where(x => x.ProjectId == projectId)
                .SelectMany(x => x.Checking.Select(x => x.CheckItem))
                .ToListAsync();

            return Ok(projectCheckItems);
        }

        [SwaggerOperation(Summary = "Create new CheckItem.")]
        [HttpPost("create")]
        public async Task<ActionResult<CheckItem>> AddCheckItem(CheckItemCreateDTO checkItemDto)
        {
            checkItemDto.Category = checkItemDto.Category.ToUpper();
            var newCheckItem = _mapper.Map<CheckItem>(checkItemDto);
            _context.CheckItems.Add(newCheckItem);
            await _context.SaveChangesAsync();

            return Ok(newCheckItem);
        }

        [SwaggerOperation(Summary = "Update CheckItem.")]
        [HttpPut("update/{checkItemId}")]
        public async Task<ActionResult<CheckItem>> UpdateCheckItem(CheckItemUpdateDTO checkItemDto, int checkItemId)
        {
            var findCheckItem = await _context.CheckItems.FirstOrDefaultAsync(x => x.CheckItemId == checkItemId);
            if (findCheckItem == null)
                return NotFound("CheckItem not found.");

            findCheckItem.Title = checkItemDto.Title;
            findCheckItem.Category = checkItemDto.Category;
            findCheckItem.Priority = checkItemDto.Priority;
            findCheckItem.Update = DateTime.Now;

            var updateCheckItem = _mapper.Map(checkItemDto, findCheckItem);
            _context.Entry(findCheckItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(updateCheckItem);
        }

        [SwaggerOperation(Summary = "Remove checkItem.")]
        [HttpDelete("delete/{checkItemId}")]
        public async Task<ActionResult> DeleteProject(int checkItemId)
        {
            var findCheckItem = await _context.CheckItems.FirstOrDefaultAsync(x => x.CheckItemId == checkItemId);
            if (findCheckItem == null)
                return NotFound("CheckItem not found.");

            _context.CheckItems.Remove(findCheckItem);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}