using Checkingx.Server.Services;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingController : ControllerBase
    {
        private readonly ICheckingService _checkingService;

        public CheckingController(ICheckingService checkingService)
        {
            _checkingService = checkingService;
        }

        [SwaggerOperation(Summary = "Return all checkings.")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Checking>>> GetAllCheckings()
        {
            return Ok(await _checkingService.GetAllCheckings());
        }

        [SwaggerOperation(Summary = "Return all checkings by project Id.")]
        [HttpGet("all/project/{projectId}")]
        public async Task<ActionResult<List<Checking>>> GetAllCheckingsByProjectId(int projectId)
        {
            return Ok(await _checkingService.GetAllCheckingsByProjectId(projectId));
        }

        [SwaggerOperation(Summary = "Return single checking entry by checking Id.")]
        [HttpGet("single/{checkingId}")]
        public async Task<ActionResult<Checking>> GetSingleCheckingById(int checkingId)
        {
            var findChecking = await _checkingService.GetSingleChecking(checkingId);
            if (findChecking == null) return NotFound("Checking not found.");
            return Ok(findChecking);
        }

        [SwaggerOperation(Summary = "Create new checking entry.")]
        [HttpPost("create")]
        public async Task<ActionResult<Checking>> PostChecking(CheckingCreateDTO modelDto)
        {
            var newChecking = await _checkingService.CreateChecking(modelDto);
            return Ok(newChecking);
        }

        [SwaggerOperation(Summary = "Mark as Fixed, single checking entry. [IsFixed] prop update. (post-Checker/designer role)")]
        [HttpPut("single/fix/{checkingId}")]
        public async Task<ActionResult<Checking>> FixError(CheckingCorrectDTO checking, int checkingId)
        {
            var findChecking = await _checkingService.FixErrorChecking(checking, checkingId);
            if (findChecking == null)
                return NotFound("Checking not found.");

            return Ok(findChecking);
        }

        [SwaggerOperation(Summary = "Mark as Correct, single checking entry. [IsError] prop update. (Checker role)")]
        [HttpPost("single/correct")]
        public async Task<ActionResult<Checking>> MarkAsCorrect(Checking checking)
        {
            var findChecking = await _checkingService.MarkAsCorrectChecking(checking);
            if (findChecking == null)
                return NotFound("Checking not found.");

            return Ok(findChecking);
        }
    }
}