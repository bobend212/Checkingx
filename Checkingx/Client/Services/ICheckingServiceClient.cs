namespace Checkingx.Client.Services
{
    public interface ICheckingServiceClient
    {
        List<Checking> CheckingList { get; set; }

        Task GetAllCheckingsByProject(int projectId);

        Task<Checking> GetSingleChecking(int checkingId);

        Task CreateCheckingItem(Checking checking);

        Task FixError(Checking checking);
    }
}