namespace Checkingx.Client.Services
{
    public interface ICheckItemServiceClient
    {
        List<CheckItem> CheckItemList { get; set; }

        Task GetAllCheckItems();

        Task<CheckItem> GetSingleCheckItem(int checkItemId);

        Task CreateCheckItem(CheckItem checkItem);

        Task UpdateCheckItem(CheckItem checkItem);

        Task DeleteCheckItem(int checkItemId);
    }
}