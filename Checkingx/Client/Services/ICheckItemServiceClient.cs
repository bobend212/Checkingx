namespace Checkingx.Client.Services
{
    public interface ICheckItemServiceClient
    {
        List<CheckItem> CheckItemList { get; set; }

        Task GetAllCheckItems();

        Task<CheckItem> GetSingleCheckItem(int checkItemId);

        Task<CheckItem> CreateCheckItem(CheckItem checkItem);

        Task UpdateCheckItem(CheckItem checkItem);

        Task DeleteCheckItem(int checkItemId);

        Task GetAllCheckItems_NotChecked(int projectId);

        Task GetAllCheckItems_Checked(int projectId);
    }
}