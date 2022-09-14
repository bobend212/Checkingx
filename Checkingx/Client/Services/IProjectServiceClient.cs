namespace Checkingx.Client.Services
{
    public interface IProjectServiceClient
    {
        List<Project> Projects { get; set; }
        List<CheckItem> CheckingList { get; set; }

        Task GetProjects();

        Task<Project> GetSingleProject(int id);

        Task CreateProject(Project project);

        Task UpdateProject(Project project);

        Task DeleteProject(int id);

        Task GetCheckingList();
    }
}