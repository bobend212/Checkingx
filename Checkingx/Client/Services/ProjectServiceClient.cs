using System.Net.Http.Json;

namespace Checkingx.Client.Services
{
    public class ProjectServiceClient : IProjectServiceClient
    {
        private readonly HttpClient _http;

        public ProjectServiceClient(HttpClient http)
        {
            _http = http;
        }

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Checking> Checkings { get; set; } = new List<Checking>();

        public async Task GetProjects()
        {
            var result = await _http.GetFromJsonAsync<List<Project>>("api/project/all");
            if (result != null)
                Projects = result;
        }

        public async Task<Project> GetSingleProject(int projectId)
        {
            var result = await _http.GetFromJsonAsync<Project>($"api/project/single/{projectId}");
            if (result != null)
                return result;

            throw new Exception("Project not found!");
        }

        public async Task<Project> CreateProject(Project project)
        {
            var result = await _http.PostAsJsonAsync("api/project/create", project);
            return await result.Content.ReadFromJsonAsync<Project>();
        }

        public async Task UpdateProject(Project project)
        {
            var result = await _http.PutAsJsonAsync($"api/project/update/{project.ProjectId}", project);
        }

        public async Task DeleteProject(int id)
        {
            var result = await _http.DeleteAsync($"api/project/delete/{id}");
        }
    }
}