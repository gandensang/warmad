namespace Dtos.Store;

public class StoreSettingsDto
{
    public int DefaultLowStockThreshold { get; set; } = 5;
    public string Currency { get; set; } = "IDR";
    public string? ReceiptHeader { get; set; }
    public string? ReceiptFooter { get; set; }
}
