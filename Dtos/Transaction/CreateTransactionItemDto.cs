namespace Dtos.Transaction;

public class CreateTransactionItemDto
{
    public string? ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; } = 1;
}
