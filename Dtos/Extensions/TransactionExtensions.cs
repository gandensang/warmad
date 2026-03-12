using Dtos.Transaction;

namespace Dtos.Extensions;

public static class TransactionExtensions
{
    public static TransactionItemDto ToDto(this Models.TransactionItem item) => new()
    {
        ProductId = item.ProductId,
        ProductName = item.ProductName,
        UnitPrice = item.UnitPrice,
        Quantity = item.Quantity,
        Subtotal = item.Subtotal,
    };

    public static Models.TransactionItem ToModel(this CreateTransactionItemDto dto) => new()
    {
        ProductId = dto.ProductId,
        ProductName = dto.ProductName,
        UnitPrice = dto.UnitPrice,
        Quantity = dto.Quantity,
    };

    public static TransactionDto ToDto(this Models.Transaction transaction) => new()
    {
        Id = transaction.Id,
        TenantId = transaction.TenantId,
        TransactionNumber = transaction.TransactionNumber,
        Items = transaction.Items.Select(i => i.ToDto()).ToList(),
        Subtotal = transaction.Subtotal,
        Discount = transaction.Discount,
        GrandTotal = transaction.GrandTotal,
        AmountPaid = transaction.AmountPaid,
        Change = transaction.Change,
        PaymentMethod = transaction.PaymentMethod,
        Status = transaction.Status,
        Note = transaction.Note,
        IsActive = transaction.IsActive,
        CreatedAt = transaction.CreatedAt,
        UpdatedAt = transaction.UpdatedAt,
    };

    public static Models.Transaction ToModel(this CreateTransactionDto dto, string tenantId, string transactionNumber) => new()
    {
        Id = Guid.NewGuid().ToString(),
        TenantId = tenantId,
        TransactionNumber = transactionNumber,
        Items = dto.Items.Select(i => i.ToModel()).ToList(),
        Discount = dto.Discount,
        AmountPaid = dto.AmountPaid,
        PaymentMethod = dto.PaymentMethod,
        Note = dto.Note,
    };
}
