using AutoMapper;
using Checkingx.Server.Data;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Checkingx.Server.Services
{
    public class CheckingService : ICheckingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CheckingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Checking>> GetAllCheckings()
        {
            return await _context.Checking.ToListAsync();
        }

        public async Task<List<Checking>> GetAllCheckingsByProjectId(int projectId)
        {
            return await _context.Checking.Where(x => x.ProjectId == projectId).Include(x => x.CheckItem).Include(x => x.Images).ToListAsync();
        }

        public async Task<Checking> GetSingleChecking(int checkingId)
        {
            return await _context.Checking.Include(x => x.Images).Include(x => x.CheckItem).FirstOrDefaultAsync(x => x.CheckingId == checkingId);
        }

        public async Task<Checking> CreateChecking(CheckingCreateDTO modelDto)
        {
            var newChecking = _mapper.Map<Checking>(modelDto);
            _context.Checking.Add(newChecking);
            await _context.SaveChangesAsync();
            return newChecking;
        }

        public async Task<Checking> FixErrorChecking(CheckingCorrectDTO checking, int checkingId)
        {
            var findChecking = await _context.Checking.FirstOrDefaultAsync(x => x.CheckingId == checkingId);
            findChecking.Status = checking.Status;
            findChecking.ReviewDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return findChecking;
        }

        public async Task<Checking> MarkAsCorrectChecking(Checking checking)
        {
            var findChecking = await _context.Checking.FirstOrDefaultAsync(x => x.CheckingId == checking.CheckingId);
            findChecking.Status = checking.Status;
            await _context.SaveChangesAsync();
            return findChecking;
        }
    }
}