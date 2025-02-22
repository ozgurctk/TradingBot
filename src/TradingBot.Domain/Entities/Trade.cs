namespace TradingBot.Domain.Entities;

public class Trade
{
    public Guid Id { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public TradeType Type { get; set; }
    public DateTime Timestamp { get; set; }
}