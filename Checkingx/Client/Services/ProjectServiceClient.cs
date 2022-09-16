using Checkingx.Client.Pages;
using Checkingx.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

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
        public List<CheckItem> CheckItemList { get; set; } = new List<CheckItem>();
        public List<Checking> Checkings { get; set; } = new List<Checking>();

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

        public async Task GetAllCheckings()
        {
            var result = await _http.GetFromJsonAsync<List<Checking>>("api/CheckingList/checkings");
            if (result != null)
                Checkings = result;
        }

        public async Task GetAllCheckItems()
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>("api/CheckingList/checkItems");
            if (result != null)
                CheckItemList = result;
        }

        public async Task<CheckItem> GetSingleCheckItem(int id)
        {
            var result = await _http.GetFromJsonAsync<CheckItem>($"api/CheckingList/{id}");
            if (result != null)
                return result;

            throw new Exception("Check Item not found!");
        }

        public async Task CreateCheckingItem(Checking checking)
        {
            var result = await _http.PostAsJsonAsync("api/CheckingList/check-item-add", checking);
        }

        public async Task<Checking> GetSingleCheckingById(int id)
        {
            var result = await _http.GetFromJsonAsync<Checking>($"api/CheckingList/checking/{id}");
            if (result != null)
                return result;

            throw new Exception("Checking not found!");
        }

        public async Task CorrectError(Checking checking)
        {
            var result = await _http.PutAsJsonAsync($"api/CheckingList/{checking.CheckingId}/correct", checking);
        }

        public async Task<List<CheckItem>> ShowOnlyCheckingsNotCheckedByProject(int projectId)
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>($"api/CheckingList/show-not-checked-by-project?projectId={projectId}");
            return result;
        }
    }
}