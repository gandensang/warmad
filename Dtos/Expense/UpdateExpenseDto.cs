namespace Dtos.Expense;

public class UpdateExpenseDto
{
    public string Category { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
