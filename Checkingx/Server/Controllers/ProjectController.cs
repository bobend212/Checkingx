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
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Return all projects (include checkings and check items).")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            return Ok(await _context.Projects.Include(x => x.Checking).ThenInclude(x => x.CheckItem).ToListAsync());
        }

        [SwaggerOperation(Summary = "Return single project (include checkings and check items).")]
        [HttpGet("single/{projectId}")]
        public async Task<ActionResult<Project>> GetProject(int projectId)
        {
            var findProject = await _context.Projects.Include(x => x.Checking).ThenInclude(x => x.CheckItem).FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (findProject == null) return NotFound("Project not found.");

            return Ok(findProject);
        }

        [SwaggerOperation(Summary = "Create new project.")]
        [HttpPost("create")]
        public async Task<ActionResult<Project>> AddProject(ProjectCreateDTO projectDto)
        {
            var newProject = _mapper.Map<Project>(projectDto);
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();

            return Ok(newProject);
        }

        [SwaggerOperation(Summary = "Update project.")]
        [HttpPut("update/{projectId}")]
        public async Task<ActionResult<Project>> UpdateProject(ProjectUpdateDTO projectDto, int projectId)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (dbProject == null)
                return NotFound("Project not found.");

            dbProject.Number = projectDto.Number;
            dbProject.Name = projectDto.Name;
            dbProject.CheckingPriority = projectDto.CheckingPriority;
            dbProject.Update = DateTime.Now;

            var updateProject = _mapper.Map(projectDto, dbProject);
            _context.Entry(dbProject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(updateProject);
        }

        [SwaggerOperation(Summary = "Remove project.")]
        [HttpDelete("delete/{projectId}")]
        public async Task<ActionResult> DeleteProject(int projectId)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            if (dbProject == null)
                return NotFound("Project not found.");

            _context.Projects.Remove(dbProject);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}