namespace Dtos.StockAdjustment;

public class StockAdjustmentItemDto
{
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int QuantityChange { get; set; }
    public int? StockBefore { get; set; }
    public int? StockAfter { get; set; }
}
