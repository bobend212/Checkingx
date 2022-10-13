using Checkingx.Shared;
using Checkingx.Shared.DTOs;

namespace Checkingx.Server.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();

        Task<Project> GetSingleProject(int projectId);

        Task<Project> CreateProject(ProjectCreateDTO project);

        Task<Project> UpdateProject(ProjectUpdateDTO project, int projectId);

        Task DeleteProject(int projectId);
    }
}