using AutoMapper;
using Checkingx.Server.Data;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Checkingx.Server.Services
{
    public class CheckItemService : ICheckItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CheckItemService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CheckItem>> GetAllCheckItems()
        {
            return await _context.CheckItems.ToListAsync();
        }

        public async Task<List<CheckItem>> GetAllCheckItemsByCategory(string category)
        {
            return await _context.CheckItems.Where(x => x.Category.ToUpper() == category.ToUpper()).ToListAsync();
        }

        public async Task<CheckItem> GetSingleCheckItem(int checkItemId)
        {
            var findCheckItem = await _context.CheckItems.FirstOrDefaultAsync(x => x.CheckItemId == checkItemId);
            return findCheckItem;
        }

        public async Task<List<CheckItem>> ShowOnlyCheckItemsNotCheckedByProject(int projectId)
        {
            var allCheckItems = await _context.CheckItems.ToListAsync();

            var projectCheckItems = await _context.Projects
                .Where(x => x.ProjectId == projectId)
                .SelectMany(x => x.Checking.Select(x => x.CheckItem))
                .ToListAsync();

            var checkItemsNotChecked = allCheckItems.Where(p => !projectCheckItems.Any(p2 => p2.CheckItemId == p.CheckItemId)).ToList();

            return checkItemsNotChecked;
        }

        public async Task<List<CheckItem>> ShowOnlyCheckItemsCheckedByProject(int projectId)
        {
            var checkedCheckItems = await _context.Projects
                .Where(x => x.ProjectId == projectId)
                .SelectMany(x => x.Checking.Select(x => x.CheckItem))
                .ToListAsync();

            return checkedCheckItems;
        }

        public async Task<CheckItem> CreateCheckItem(CheckItemCreateDTO checkItemDto)
        {
            checkItemDto.Category = checkItemDto.Category.ToUpper();
            var newCheckItem = _mapper.Map<CheckItem>(checkItemDto);
            _context.CheckItems.Add(newCheckItem);
            await _context.SaveChangesAsync();
            return newCheckItem;
        }

        public async Task<CheckItem> UpdateCheckItem(CheckItemUpdateDTO checkItem, int checkItemId)
        {
            var findCheckItem = await _context.CheckItems.FirstOrDefaultAsync(x => x.CheckItemId == checkItemId);

            findCheckItem.Title = checkItem.Title;
            findCheckItem.Category = checkItem.Category;
            findCheckItem.Priority = checkItem.Priority;
            findCheckItem.Update = DateTime.Now;

            var updateCheckItem = _mapper.Map(checkItem, findCheckItem);
            _context.Entry(findCheckItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateCheckItem;
        }

        public async Task DeleteCheckItem(int checkItemId)
        {
            var findCheckItem = await _context.CheckItems.FirstOrDefaultAsync(x => x.CheckItemId == checkItemId);
            _context.CheckItems.Remove(findCheckItem);
            await _context.SaveChangesAsync();
        }
    }
}