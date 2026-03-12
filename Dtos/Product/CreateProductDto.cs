namespace Dtos.Product;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? CostPrice { get; set; }
    public int? Stock { get; set; }
    public int LowStockThreshold { get; set; } = 5;
    public string Unit { get; set; } = "pcs";
    public string? Barcode { get; set; }
    public string? Category { get; set; }
}
