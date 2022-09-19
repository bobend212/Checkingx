namespace Checkingx.Client.Services
{
    public interface ICheckingServiceClient
    {
        List<Checking> CheckingList { get; set; }

        Task GetAllCheckingsByProject(int projectId);

        Task CreateCheckingItem(Checking checking);
    }
}