namespace Dtos.DailySummary;

public class DailySummaryDto
{
    public string Id { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal NetCash { get; set; }
    public int TransactionCount { get; set; }
    public Dictionary<string, decimal> ExpenseBreakdown { get; set; } = [];
    public List<TopProductEntryDto> TopProducts { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
