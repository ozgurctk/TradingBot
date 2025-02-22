using TradingBot.Domain.Entities;
using TradingBot.Domain.Interfaces;
using TradingBot.Application.ViewModels;

namespace TradingBot.Application.Services;

public interface ITradeService
{
    Task<TradeDto> GetTradeByIdAsync(Guid id);
    Task<IEnumerable<TradeDto>> GetAllTradesAsync();
    Task<TradeDto> CreateTradeAsync(CreateTradeCommand command);
    Task UpdateTradeAsync(UpdateTradeCommand command);
    Task DeleteTradeAsync(Guid id);
}

public class TradeService : ITradeService
{
    private readonly ITradeRepository _tradeRepository;

    public TradeService(ITradeRepository tradeRepository)
    {
        _tradeRepository = tradeRepository;
    }

    public async Task<TradeDto> GetTradeByIdAsync(Guid id)
    {
        var trade = await _tradeRepository.GetByIdAsync(id);
        return trade != null ? new TradeDto(trade) : null;
    }

    public async Task<IEnumerable<TradeDto>> GetAllTradesAsync()
    {
        var trades = await _tradeRepository.GetAllAsync();
        return trades.Select(t => new TradeDto(t));
    }

    public async Task<TradeDto> CreateTradeAsync(CreateTradeCommand command)
    {
        var trade = new Trade
        {
            Symbol = command.Symbol,
            Price = command.Price,
            Quantity = command.Quantity,
            Type = command.Type,
            Timestamp = DateTime.UtcNow
        };

        var createdTrade = await _tradeRepository.AddAsync(trade);
        return new TradeDto(createdTrade);
    }

    public async Task UpdateTradeAsync(UpdateTradeCommand command)
    {
        var trade = await _tradeRepository.GetByIdAsync(command.Id);
        if (trade == null) throw new KeyNotFoundException($"Trade with ID {command.Id} not found");

        trade.Symbol = command.Symbol;
        trade.Price = command.Price;
        trade.Quantity = command.Quantity;
        trade.Type = command.Type;

        await _tradeRepository.UpdateAsync(trade);
    }

    public async Task DeleteTradeAsync(Guid id)
    {
        await _tradeRepository.DeleteAsync(id);
    }
}