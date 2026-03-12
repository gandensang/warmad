using System.Text.Json.Serialization;
using Commons;

namespace Models;

/// <summary>
/// Store = toko/warung fisik di bawah satu Tenant.
/// Satu tenant bisa punya beberapa store (misal: "Warung Madura Cabang A", "Cabang B").
/// 
/// Disimpan di container "pos-data" dengan partition key /tenantId.
/// </summary>
public class Store : BaseEntity
{
    /// <summary>Nama toko, e.g. "Warung Berkah Jaya"</summary>
    public string Name { get; set; } = string.Empty;
    
    public string? Address { get; set; }
    
    public string? Phone { get; set; }

    public string DocumentType { get; set; } = StaticDocumentType.Store;
 
    /// <summary>
    /// Pengaturan per store: threshold stok rendah default, dll.
    /// </summary>
    [JsonPropertyName("settings")]
    public StoreSettings Settings { get; set; } = new();
}

/// <summary>
/// Pengaturan per store — bisa di-customize oleh pemilik
/// </summary>
public class StoreSettings
{
    /// <summary>Default threshold stok rendah untuk produk baru</summary>
    public int DefaultLowStockThreshold { get; set; } = 5;
 
    /// <summary>Mata uang (default IDR)</summary>
    public string Currency { get; set; } = "IDR";
 
    /// <summary>Format struk: nama toko di header</summary>
    public string? ReceiptHeader { get; set; }
 
    /// <summary>Format struk: pesan di footer, e.g. "Terima kasih!"</summary>
    public string? ReceiptFooter { get; set; }
}