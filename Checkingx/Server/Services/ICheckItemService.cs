using Checkingx.Shared;
using Checkingx.Shared.DTOs;

namespace Checkingx.Server.Services
{
    public interface ICheckItemService
    {
        Task<List<CheckItem>> GetAllCheckItems();

        Task<List<CheckItem>> GetAllCheckItemsByCategory(string category);

        Task<CheckItem> GetSingleCheckItem(int checkItemId);

        Task<List<CheckItem>> ShowOnlyCheckItemsNotCheckedByProject(int projectId);

        Task<List<CheckItem>> ShowOnlyCheckItemsCheckedByProject(int projectId);

        Task<CheckItem> CreateCheckItem(CheckItemCreateDTO checkItemDto);

        Task<CheckItem> UpdateCheckItem(CheckItemUpdateDTO checkItem, int checkItemId);

        Task DeleteCheckItem(int checkItemId);
    }
}