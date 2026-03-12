namespace Dtos.Store;

public class UpdateStoreDto
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public StoreSettingsDto Settings { get; set; } = new();
    public bool IsActive { get; set; } = true;
}
