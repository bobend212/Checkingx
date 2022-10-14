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
            var result = await _http.GetFromJsonAsync<List<Checking>>($"api/Checking/all/project/{projectId}");
            if (result != null)
                CheckingList = result;
        }

        public async Task<Checking> GetSingleChecking(int checkingId)
        {
            var result = await _http.GetFromJsonAsync<Checking>($"api/Checking/single/{checkingId}");
            if (result != null)
                return result;

            throw new Exception("Checking not found!");
        }

        public async Task CreateCheckingItem(Checking checking)
        {
            var result = await _http.PostAsJsonAsync("api/Checking/create", checking);
        }

        public async Task FixError(Checking checking)
        {
            var result = await _http.PutAsJsonAsync($"api/Checking/single/fix/{checking.CheckingId}", checking);
        }
    }
}