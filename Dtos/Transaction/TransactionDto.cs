namespace Dtos.Transaction;

public class TransactionDto
{
    public string Id { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string TransactionNumber { get; set; } = string.Empty;
    public List<TransactionItemDto> Items { get; set; } = [];
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal GrandTotal { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal Change { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Note { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
