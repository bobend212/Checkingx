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

        public async Task CreateProject(Project project)
        {
            var result = await _http.PostAsJsonAsync("api/project/create", project);
        }

        public async Task UpdateProject(Project project)
        {
            var result = await _http.PutAsJsonAsync($"api/project/update/{project.ProjectId}", project);
        }

        public async Task DeleteProject(int id)
        {
            var result = await _http.DeleteAsync($"api/project/delete/{id}");
        }

        private async Task SetProjects(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Project>>();
            Projects = response;
            _navigationManager.NavigateTo("projects");
        }


        //

        public async Task CreateCheckingItem(Checking checking)
        {
            var result = await _http.PostAsJsonAsync("api/CheckingList/check-item-add", checking);
        }

        public async Task FixError(Checking checking)
        {
            var result = await _http.PutAsJsonAsync($"api/CheckingList/single/fix/{checking.CheckingId}", checking);
        }
    }
}