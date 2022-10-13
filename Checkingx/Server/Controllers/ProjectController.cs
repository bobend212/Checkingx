using Checkingx.Server.Services;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [SwaggerOperation(Summary = "Return all projects (include checkings and check items).")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            return Ok(await _projectService.GetAllProjects());
        }

        [SwaggerOperation(Summary = "Return single project (include checkings and check items).")]
        [HttpGet("single/{projectId}")]
        public async Task<ActionResult<Project>> GetProject(int projectId)
        {
            var findProject = await _projectService.GetSingleProject(projectId);
            if (findProject == null) return NotFound("Project not found.");
            return Ok(findProject);
        }

        [SwaggerOperation(Summary = "Create new project.")]
        [HttpPost("create")]
        public async Task<ActionResult<Project>> AddProject(ProjectCreateDTO projectDto)
        {
            var newProject = await _projectService.CreateProject(projectDto);
            return Ok(newProject);
        }

        [SwaggerOperation(Summary = "Update project.")]
        [HttpPut("update/{projectId}")]
        public async Task<ActionResult<Project>> UpdateProject(ProjectUpdateDTO projectDto, int projectId)
        {
            var updateProject = await _projectService.UpdateProject(projectDto, projectId);
            if (updateProject == null)
                return NotFound("Project not found.");

            return Ok(updateProject);
        }

        [SwaggerOperation(Summary = "Remove project.")]
        [HttpDelete("delete/{projectId}")]
        public async Task<ActionResult> DeleteProject(int projectId)
        {
            var findProject = await _projectService.GetSingleProject(projectId);
            if (findProject == null)
                return NotFound("Project not found.");

            await _projectService.DeleteProject(projectId);
            return Ok();
        }
    }
}