using Checkingx.Server.Data;
using Checkingx.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var findProject = await _context.Projects.FindAsync(id);
            if (findProject == null) return NotFound("Project not found.");

            return Ok(findProject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Project>>> UpdateProject(Project project, int id)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (dbProject == null)
                return NotFound("Project not found.");

            dbProject.Number = project.Number;
            dbProject.Name = project.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Project>>> DeleteProject(int id)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (dbProject == null)
                return NotFound("Project not found.");

            _context.Projects.Remove(dbProject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Projects.ToListAsync());
        }
    }
}