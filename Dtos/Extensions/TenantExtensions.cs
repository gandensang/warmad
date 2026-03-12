using Dtos.Tenant;

namespace Dtos.Extensions;

public static class TenantExtensions
{
    public static TenantDto ToDto(this Models.Tenant tenant) => new()
    {
        Id = tenant.Id,
        TenantId = tenant.TenantId,
        BusinessName = tenant.BusinessName,
        OwnerName = tenant.OwnerName,
        Email = tenant.Email,
        Phone = tenant.Phone,
        Plan = tenant.Plan,
        MaxStores = tenant.MaxStores,
        IsActive = tenant.IsActive,
        CreatedAt = tenant.CreatedAt,
        UpdatedAt = tenant.UpdatedAt,
    };

    public static Models.Tenant ToModel(this CreateTenantDto dto) => new()
    {
        Id = Guid.NewGuid().ToString(),
        TenantId = Guid.NewGuid().ToString(),
        BusinessName = dto.BusinessName,
        OwnerName = dto.OwnerName,
        Email = dto.Email,
        Phone = dto.Phone,
    };

    public static void ApplyUpdate(this Models.Tenant tenant, UpdateTenantDto dto)
    {
        tenant.BusinessName = dto.BusinessName;
        tenant.OwnerName = dto.OwnerName;
        tenant.Phone = dto.Phone;
        tenant.Plan = dto.Plan;
        tenant.MaxStores = dto.MaxStores;
        tenant.IsActive = dto.IsActive;
        tenant.UpdatedAt = DateTime.UtcNow;
    }
}
