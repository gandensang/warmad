using System.Text.Json.Serialization;
using Commons;

namespace Models;

/// <summary>
/// Tenant = subscriber/pemilik akun SaaS.
/// Satu tenant bisa memiliki beberapa Store (warung/toko).
/// 
/// Disimpan di container terpisah "tenants" dengan partition key /id
/// agar tidak bercampur dengan data operasional.
/// </summary>
public class Tenant : BaseEntity
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();
 
    /// <summary>Nama bisnis / pemilik</summary>
    public string BusinessName { get; set; } = string.Empty;
 
    /// <summary>Nama pemilik</summary>
    public string OwnerName { get; set; } = string.Empty;
 
    /// <summary>Email untuk login & notifikasi</summary>
    public string Email { get; set; } = string.Empty;
 
    /// <summary>No HP</summary>
    public string? Phone { get; set; }
 
    /// <summary>Tier langganan</summary>
    public string Plan { get; set; } = StaticSubcriptionPlan.Free;
    
    /// <summary>Maksimal jumlah store sesuai plan</summary>
    [JsonPropertyName("maxStores")]
    public int MaxStores { get; set; } = 1;
}