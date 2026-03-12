namespace Dtos.StockAdjustment;

public class CreateStockAdjustmentItemDto
{
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int QuantityChange { get; set; }
}
