namespace Dtos.StockAdjustment;

public class CreateStockAdjustmentDto
{
    public string Reason { get; set; } = "stok_masuk";
    public List<CreateStockAdjustmentItemDto> Items { get; set; } = [];
    public string? Note { get; set; }
    public string? ExpenseId { get; set; }
}
