using TradingBot.Domain.Entities;
using TradingBot.Domain.Enums;

namespace TradingBot.Application.ViewModels;

public record TradeDto
{
    public Guid Id { get; init; }
    public string Symbol { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public TradeType Type { get; init; }
    public DateTime Timestamp { get; init; }

    public TradeDto(Trade trade)
    {
        Id = trade.Id;
        Symbol = trade.Symbol;
        Price = trade.Price;
        Quantity = trade.Quantity;
        Type = trade.Type;
        Timestamp = trade.Timestamp;
    }
}

public record CreateTradeCommand
{
    public string Symbol { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public TradeType Type { get; init; }
}

public record UpdateTradeCommand
{
    public Guid Id { get; init; }
    public string Symbol { get; init; }
    public decimal Price { get; init; }
    public decimal Quantity { get; init; }
    public TradeType Type { get; init; }
}