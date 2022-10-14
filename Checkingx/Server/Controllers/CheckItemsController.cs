using Checkingx.Server.Services;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckItemsController : ControllerBase
    {
        private readonly ICheckItemService _checkItemService;
        private readonly IProjectService _projectService;

        public CheckItemsController(ICheckItemService checkItemService, IProjectService projectService)
        {
            _checkItemService = checkItemService;
            _projectService = projectService;
        }

        [SwaggerOperation(Summary = "Return all check items.")]
        [HttpGet("all")]
        public async Task<ActionResult<List<CheckItem>>> GetAllCheckItems()
        {
            return Ok(await _checkItemService.GetAllCheckItems());
        }

        [SwaggerOperation(Summary = "Return all check items for specified category.")]
        [HttpGet("all/{category}")]
        public async Task<ActionResult<List<CheckItem>>> GetAllCheckItemsByCategory(string category)
        {
            return Ok(await _checkItemService.GetAllCheckItemsByCategory(category));
        }

        [SwaggerOperation(Summary = "Return single CheckItem entry by CheckItemId.")]
        [HttpGet("single/{checkItemId}")]
        public async Task<ActionResult<CheckItem>> GetSingleCheckItem(int checkItemId)
        {
            var findCheckItem = await _checkItemService.GetSingleCheckItem(checkItemId);
            if (findCheckItem == null) return NotFound("Check Item not found.");
            return Ok(findCheckItem);
        }

        [SwaggerOperation(Summary = "Return all CheckItems NOT CHECKED by projectId.")]
        [HttpGet("project/{projectId}/not-checked")]
        public async Task<ActionResult<List<CheckItem>>> ShowOnlyCheckItemsNotCheckedByProject(int projectId)
        {
            var findProject = await _projectService.GetSingleProject(projectId);
            if (findProject == null) return NotFound("Project not found.");

            var notCheckedCheckItems = await _checkItemService.ShowOnlyCheckItemsNotCheckedByProject(projectId);
            return Ok(notCheckedCheckItems);
        }

        [SwaggerOperation(Summary = "Return all CheckItems CHECKED by projectId.")]
        [HttpGet("project/{projectId}/checked")]
        public async Task<ActionResult<List<CheckItem>>> ShowOnlyCheckItemsCheckedByProject(int projectId)
        {
            var findProject = await _projectService.GetSingleProject(projectId);
            if (findProject == null) return NotFound("Project not found.");

            var checkiedCheckItems = await _checkItemService.ShowOnlyCheckItemsCheckedByProject(projectId);
            return Ok(checkiedCheckItems);
        }

        [SwaggerOperation(Summary = "Create new CheckItem.")]
        [HttpPost("create")]
        public async Task<ActionResult<CheckItem>> AddCheckItem(CheckItemCreateDTO checkItemDto)
        {
            var newCheckItem = await _checkItemService.CreateCheckItem(checkItemDto);
            return Ok(newCheckItem);
        }

        [SwaggerOperation(Summary = "Update CheckItem.")]
        [HttpPut("update/{checkItemId}")]
        public async Task<ActionResult<CheckItem>> UpdateCheckItem(CheckItemUpdateDTO checkItemDto, int checkItemId)
        {
            var updateCheckItem = await _checkItemService.UpdateCheckItem(checkItemDto, checkItemId);
            if (updateCheckItem == null)
                return NotFound("CheckItem not found.");

            return Ok(updateCheckItem);
        }

        [SwaggerOperation(Summary = "Remove checkItem.")]
        [HttpDelete("delete/{checkItemId}")]
        public async Task<ActionResult> DeleteProject(int checkItemId)
        {
            var findCheckItem = await _checkItemService.GetSingleCheckItem(checkItemId);
            if (findCheckItem == null)
                return NotFound("CheckItem not found.");

            await _checkItemService.DeleteCheckItem(checkItemId);
            return Ok();
        }
    }
}