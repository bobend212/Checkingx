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

        public async Task GetProjects()
        {
            var result = await _http.GetFromJsonAsync<List<Project>>("api/project");
            if (result != null)
                Projects = result;
        }

        public async Task<Project> GetSingleProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}