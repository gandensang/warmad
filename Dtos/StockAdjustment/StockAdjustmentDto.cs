namespace Dtos.StockAdjustment;

public class StockAdjustmentDto
{
    public string Id { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public List<StockAdjustmentItemDto> Items { get; set; } = [];
    public string? Note { get; set; }
    public string? ExpenseId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
