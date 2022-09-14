namespace Checkingx.Client.Services
{
    public interface IProjectServiceClient
    {
        List<Project> Projects { get; set; }

        Task GetProjects();

        Task<Project> GetSingleProject(int id);

        Task CreateProject(Project project);

        Task UpdateProject(Project project);

        Task DeleteProject(int id);
    }
}