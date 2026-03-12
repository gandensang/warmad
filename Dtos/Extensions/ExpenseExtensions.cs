using Dtos.Expense;

namespace Dtos.Extensions;

public static class ExpenseExtensions
{
    public static ExpenseDto ToDto(this Models.Expense expense) => new()
    {
        Id = expense.Id,
        TenantId = expense.TenantId,
        Category = expense.Category,
        Amount = expense.Amount,
        Description = expense.Description,
        StockAdjustmentId = expense.StockAdjustmentId,
        HasStockUpdate = expense.HasStockUpdate,
        IsActive = expense.IsActive,
        CreatedAt = expense.CreatedAt,
        UpdatedAt = expense.UpdatedAt,
    };

    public static Models.Expense ToModel(this CreateExpenseDto dto, string tenantId) => new()
    {
        Id = Guid.NewGuid().ToString(),
        TenantId = tenantId,
        Category = dto.Category,
        Amount = dto.Amount,
        Description = dto.Description,
    };

    public static void ApplyUpdate(this Models.Expense expense, UpdateExpenseDto dto)
    {
        expense.Category = dto.Category;
        expense.Amount = dto.Amount;
        expense.Description = dto.Description;
        expense.IsActive = dto.IsActive;
        expense.UpdatedAt = DateTime.UtcNow;
    }
}
