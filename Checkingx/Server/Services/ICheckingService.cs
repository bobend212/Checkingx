using Checkingx.Shared;
using Checkingx.Shared.DTOs;

namespace Checkingx.Server.Services
{
    public interface ICheckingService
    {
        Task<List<Checking>> GetAllCheckings();

        Task<List<Checking>> GetAllCheckingsByProjectId(int projectId);

        Task<Checking> GetSingleChecking(int checkingId);

        Task<Checking> CreateChecking(CheckingCreateDTO modelDto);

        Task<Checking> FixErrorChecking(CheckingCorrectDTO checking, int checkingId);

        Task<Checking> MarkAsCorrectChecking(Checking checking);
    }
}