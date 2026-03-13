namespace SqliteModel;

/// <summary>
/// Base entity untuk SQLite — single user, tanpa TenantId.
/// Id menggunakan Guid string, konsisten dengan Models CosmosDb.
/// </summary>
public abstract class BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
