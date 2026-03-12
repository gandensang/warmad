namespace Dtos.DailySummary;

public class TopProductEntryDto
{
    public string? ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int QuantitySold { get; set; }
    public decimal TotalRevenue { get; set; }
}
