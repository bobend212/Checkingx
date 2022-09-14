using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Checkingx.Client.Services
{
    public class ProjectServiceClient : IProjectServiceClient
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProjectServiceClient(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<CheckItem> CheckingList { get; set; } = new List<CheckItem>();

        public async Task GetProjects()
        {
            var result = await _http.GetFromJsonAsync<List<Project>>("api/project");
            if (result != null)
                Projects = result;
        }

        public async Task<Project> GetSingleProject(int id)
        {
            var result = await _http.GetFromJsonAsync<Project>($"api/project/{id}");
            if (result != null)
                return result;

            throw new Exception("Project not found!");
        }

        public async Task CreateProject(Project project)
        {
            var result = await _http.PostAsJsonAsync("api/project", project);
            var response = await result.Content.ReadFromJsonAsync<List<Project>>();
            Projects = response;
        }

        public async Task UpdateProject(Project project)
        {
            var result = await _http.PutAsJsonAsync($"api/project/{project.ProjectId}", project);
            await SetProjects(result);
        }

        public async Task DeleteProject(int id)
        {
            var result = await _http.DeleteAsync($"api/project/{id}");
            await SetProjects(result);
        }

        private async Task SetProjects(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Project>>();
            Projects = response;
            _navigationManager.NavigateTo("projects");
        }

        public async Task GetCheckingList()
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>("api/CheckingList");
            if (result != null)
                CheckingList = result;
        }

        public async Task<CheckItem> GetSingleCheckItem(int id)
        {
            var result = await _http.GetFromJsonAsync<CheckItem>($"api/CheckingList/{id}");
            if (result != null)
                return result;

            throw new Exception("Check Item not found!");
        }
    }
}