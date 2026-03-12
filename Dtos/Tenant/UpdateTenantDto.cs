namespace Dtos.Tenant;

public class UpdateTenantDto
{
    public string BusinessName { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Plan { get; set; } = string.Empty;
    public int MaxStores { get; set; }
    public bool IsActive { get; set; } = true;
}
