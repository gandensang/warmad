namespace Dtos.Transaction;

public class CreateTransactionDto
{
    public List<CreateTransactionItemDto> Items { get; set; } = [];
    public decimal Discount { get; set; }
    public decimal AmountPaid { get; set; }
    public string PaymentMethod { get; set; } = "cash";
    public string? Note { get; set; }
}
