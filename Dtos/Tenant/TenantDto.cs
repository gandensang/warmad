namespace Dtos.Tenant;

public class TenantDto
{
    public string Id { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
    public string BusinessName { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Plan { get; set; } = string.Empty;
    public int MaxStores { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
