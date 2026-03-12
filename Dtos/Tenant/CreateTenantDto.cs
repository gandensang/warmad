namespace Dtos.Tenant;

public class CreateTenantDto
{
    public string BusinessName { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
}
