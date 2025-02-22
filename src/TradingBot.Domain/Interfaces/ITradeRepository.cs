using TradingBot.Domain.Entities;

namespace TradingBot.Domain.Interfaces;

public interface ITradeRepository
{
    Task<Trade> GetByIdAsync(Guid id);
    Task<IEnumerable<Trade>> GetAllAsync();
    Task<Trade> AddAsync(Trade trade);
    Task UpdateAsync(Trade trade);
    Task DeleteAsync(Guid id);
}