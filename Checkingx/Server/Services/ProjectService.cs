using AutoMapper;
using Checkingx.Server.Data;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Checkingx.Server.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _context.Projects.Include(x => x.Checking).ThenInclude(x => x.CheckItem).ToListAsync();
        }

        public async Task<Project> GetSingleProject(int projectId)
        {
            var findProject = await _context.Projects.Include(x => x.Checking).ThenInclude(x => x.CheckItem).FirstOrDefaultAsync(x => x.ProjectId == projectId);
            return findProject;
        }

        public async Task<Project> CreateProject(ProjectCreateDTO project)
        {
            var newProject = _mapper.Map<Project>(project);
            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
            return newProject;
        }

        public async Task<Project> UpdateProject(ProjectUpdateDTO project, int projectId)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            dbProject.Number = project.Number;
            dbProject.Name = project.Name;
            dbProject.CheckingPriority = project.CheckingPriority;
            dbProject.Update = DateTime.Now;

            var updateProject = _mapper.Map(project, dbProject);
            _context.Entry(dbProject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dbProject;
        }

        public async Task DeleteProject(int projectId)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
            _context.Projects.Remove(dbProject);
            await _context.SaveChangesAsync();
        }
    }
}