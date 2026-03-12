using Dtos.Store;

namespace Dtos.Extensions;

public static class StoreExtensions
{
    public static StoreSettingsDto ToDto(this Models.StoreSettings settings) => new()
    {
        DefaultLowStockThreshold = settings.DefaultLowStockThreshold,
        Currency = settings.Currency,
        ReceiptHeader = settings.ReceiptHeader,
        ReceiptFooter = settings.ReceiptFooter,
    };

    public static Models.StoreSettings ToModel(this StoreSettingsDto dto) => new()
    {
        DefaultLowStockThreshold = dto.DefaultLowStockThreshold,
        Currency = dto.Currency,
        ReceiptHeader = dto.ReceiptHeader,
        ReceiptFooter = dto.ReceiptFooter,
    };

    public static StoreDto ToDto(this Models.Store store) => new()
    {
        TenantId = store.TenantId,
        Name = store.Name,
        Address = store.Address,
        Phone = store.Phone,
        Settings = store.Settings.ToDto(),
        IsActive = store.IsActive,
        CreatedAt = store.CreatedAt,
        UpdatedAt = store.UpdatedAt,
    };

    public static Models.Store ToModel(this CreateStoreDto dto, string tenantId) => new()
    {
        TenantId = tenantId,
        Name = dto.Name,
        Address = dto.Address,
        Phone = dto.Phone,
        Settings = dto.Settings.ToModel(),
    };

    public static void ApplyUpdate(this Models.Store store, UpdateStoreDto dto)
    {
        store.Name = dto.Name;
        store.Address = dto.Address;
        store.Phone = dto.Phone;
        store.Settings = dto.Settings.ToModel();
        store.IsActive = dto.IsActive;
        store.UpdatedAt = DateTime.UtcNow;
    }
}
