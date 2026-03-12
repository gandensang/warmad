namespace Dtos.Expense;

public class CreateExpenseDto
{
    public string Category { get; set; } = "belanja_stok";
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
}
