using Dtos.StockAdjustment;

namespace Dtos.Extensions;

public static class StockAdjustmentExtensions
{
    public static StockAdjustmentItemDto ToDto(this Models.StockAdjustmentItem item) => new()
    {
        ProductId = item.ProductId,
        ProductName = item.ProductName,
        QuantityChange = item.QuantityChange,
        StockBefore = item.StockBefore,
        StockAfter = item.StockAfter,
    };

    public static Models.StockAdjustmentItem ToModel(this CreateStockAdjustmentItemDto dto) => new()
    {
        ProductId = dto.ProductId,
        ProductName = dto.ProductName,
        QuantityChange = dto.QuantityChange,
    };

    public static StockAdjustmentDto ToDto(this Models.StockAdjustment adjustment) => new()
    {
        Id = adjustment.Id,
        TenantId = adjustment.TenantId,
        Reason = adjustment.Reason,
        Items = adjustment.Items.Select(i => i.ToDto()).ToList(),
        Note = adjustment.Note,
        ExpenseId = adjustment.ExpenseId,
        IsActive = adjustment.IsActive,
        CreatedAt = adjustment.CreatedAt,
        UpdatedAt = adjustment.UpdatedAt,
    };

    public static Models.StockAdjustment ToModel(this CreateStockAdjustmentDto dto, string tenantId) => new()
    {
        Id = Guid.NewGuid().ToString(),
        TenantId = tenantId,
        Reason = dto.Reason,
        Items = dto.Items.Select(i => i.ToModel()).ToList(),
        Note = dto.Note,
        ExpenseId = dto.ExpenseId,
    };
}
