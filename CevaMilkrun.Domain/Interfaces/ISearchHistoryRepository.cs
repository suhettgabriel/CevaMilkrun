using CevaMilkrun.Domain.Entities;

namespace CevaMilkrun.Domain.Interfaces
{
    public interface ISearchHistoryRepository
    {
        Task AddAsync(SearchHistory history);
        Task<IEnumerable<SearchHistory>> GetRecentByPhoneAsync(string phoneNumber, int count = 5);
        Task SaveChangesAsync();
    }
}