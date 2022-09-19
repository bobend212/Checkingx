using System.Net.Http.Json;

namespace Checkingx.Client.Services
{
    public class CheckItemServiceClient : ICheckItemServiceClient
    {
        private readonly HttpClient _http;

        public CheckItemServiceClient(HttpClient http)
        {
            _http = http;
        }

        public List<CheckItem> CheckItemList { get; set; } = new();

        public async Task GetAllCheckItems()
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>("api/CheckItems/all");
            if (result != null)
                CheckItemList = result;
        }

        public async Task<CheckItem> GetSingleCheckItem(int checkItemId)
        {
            var result = await _http.GetFromJsonAsync<CheckItem>($"api/CheckItems/single/{checkItemId}");
            if (result != null)
                return result;

            throw new Exception("Check Item not found!");
        }

        public async Task CreateCheckItem(CheckItem checkItem)
        {
            var result = await _http.PostAsJsonAsync("api/CheckItems/create", checkItem);
        }

        public async Task UpdateCheckItem(CheckItem checkItem)
        {
            var result = await _http.PutAsJsonAsync($"api/CheckItems/update/{checkItem.CheckItemId}", checkItem);
        }

        public async Task DeleteCheckItem(int checkItemId)
        {
            var result = await _http.DeleteAsync($"api/CheckItems/delete/{checkItemId}");
        }
    }
}