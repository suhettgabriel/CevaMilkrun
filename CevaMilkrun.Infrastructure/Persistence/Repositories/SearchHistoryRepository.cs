using CevaMilkrun.Domain.Entities;
using CevaMilkrun.Domain.Interfaces;
using CevaMilkrun.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace CevaMilkrun.Infrastructure.Persistence.Repositories
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SearchHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SearchHistory history)
        {
            await _context.SearchHistories.AddAsync(history);
        }

        public async Task<IEnumerable<SearchHistory>> GetRecentByPhoneAsync(string phoneNumber, int count)
        {
            return await _context.SearchHistories
                .AsNoTracking()
                .Where(x => x.PhoneNumber == phoneNumber)
                .OrderByDescending(x => x.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}