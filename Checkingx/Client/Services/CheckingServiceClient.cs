using Checkingx.Client.Pages.CheckItems;
using System.Net.Http.Json;

namespace Checkingx.Client.Services
{
    public class CheckingServiceClient : ICheckingServiceClient
    {
        private readonly HttpClient _http;

        public CheckingServiceClient(HttpClient http)
        {
            _http = http;
        }

        public List<Checking> CheckingList { get; set; } = new();

        public async Task GetAllCheckingsByProject(int projectId)
        {
            var result = await _http.GetFromJsonAsync<List<Checking>>($"api/CheckingList/all/project/{projectId}");
            if (result != null)
                CheckingList = result;
        }
    }
}