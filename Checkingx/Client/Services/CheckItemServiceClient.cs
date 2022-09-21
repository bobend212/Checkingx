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

        public async Task GetAllCheckItemsByCategory(string category)
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>($"api/CheckItems/all/{category}");
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

        public async Task<CheckItem> CreateCheckItem(CheckItem checkItem)
        {
            var result = await _http.PostAsJsonAsync("api/CheckItems/create", checkItem);
            return await result.Content.ReadFromJsonAsync<CheckItem>();
        }

        public async Task UpdateCheckItem(CheckItem checkItem)
        {
            var result = await _http.PutAsJsonAsync($"api/CheckItems/update/{checkItem.CheckItemId}", checkItem);
        }

        public async Task DeleteCheckItem(int checkItemId)
        {
            var result = await _http.DeleteAsync($"api/CheckItems/delete/{checkItemId}");
        }

        public async Task GetAllCheckItems_NotChecked(int projectId)
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>($"api/CheckItems/project/{projectId}/not-checked");
            if (result != null)
                CheckItemList = result;
        }

        public async Task GetAllCheckItems_Checked(int projectId)
        {
            var result = await _http.GetFromJsonAsync<List<CheckItem>>($"api/CheckItems/project/{projectId}/checked");
            if (result != null)
                CheckItemList = result;
        }
    }
}