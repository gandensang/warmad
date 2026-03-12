using Dtos.DailySummary;

namespace Dtos.Extensions;

public static class DailySummaryExtensions
{
    public static TopProductEntryDto ToDto(this Models.TopProductEntry entry) => new()
    {
        ProductId = entry.ProductId,
        ProductName = entry.ProductName,
        QuantitySold = entry.QuantitySold,
        TotalRevenue = entry.TotalRevenue,
    };

    public static DailySummaryDto ToDto(this Models.DailySummary summary) => new()
    {
        Id = summary.Id,
        TenantId = summary.TenantId,
        Date = summary.Date,
        TotalIncome = summary.TotalIncome,
        TotalExpense = summary.TotalExpense,
        NetCash = summary.NetCash,
        TransactionCount = summary.TransactionCount,
        ExpenseBreakdown = summary.ExpenseBreakdown
            .ToDictionary(kv => kv.Key.ToString()!, kv => kv.Value),
        TopProducts = summary.TopProducts.Select(p => p.ToDto()).ToList(),
        CreatedAt = summary.CreatedAt,
        UpdatedAt = summary.UpdatedAt,
    };
}
