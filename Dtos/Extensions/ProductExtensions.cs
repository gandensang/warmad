using Dtos.Product;

namespace Dtos.Extensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this Models.Product product) => new()
    {
        Id = product.Id,
        TenantId = product.TenantId,
        Name = product.Name,
        Price = product.Price,
        CostPrice = product.CostPrice,
        Stock = product.Stock,
        LowStockThreshold = product.LowStockThreshold,
        Unit = product.Unit,
        Barcode = product.Barcode,
        Category = product.Category,
        IsLowStock = product.IsLowStock,
        IsActive = product.IsActive,
        CreatedAt = product.CreatedAt,
        UpdatedAt = product.UpdatedAt,
    };

    public static Models.Product ToModel(this CreateProductDto dto, string tenantId) => new()
    {
        Id = Guid.NewGuid().ToString(),
        TenantId = tenantId,
        Name = dto.Name,
        Price = dto.Price,
        CostPrice = dto.CostPrice,
        Stock = dto.Stock,
        LowStockThreshold = dto.LowStockThreshold,
        Unit = dto.Unit,
        Barcode = dto.Barcode,
        Category = dto.Category,
    };

    public static void ApplyUpdate(this Models.Product product, UpdateProductDto dto)
    {
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.CostPrice = dto.CostPrice;
        product.Stock = dto.Stock;
        product.LowStockThreshold = dto.LowStockThreshold;
        product.Unit = dto.Unit;
        product.Barcode = dto.Barcode;
        product.Category = dto.Category;
        product.IsActive = dto.IsActive;
        product.UpdatedAt = DateTime.UtcNow;
    }
}
