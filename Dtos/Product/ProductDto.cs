namespace Dtos.Product;

public class ProductDto
{
    public string Id { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? CostPrice { get; set; }
    public int? Stock { get; set; }
    public int LowStockThreshold { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? Barcode { get; set; }
    public string? Category { get; set; }
    public bool IsLowStock { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
