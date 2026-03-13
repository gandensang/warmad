using Microsoft.EntityFrameworkCore;

namespace SqliteModel;

/// <summary>
/// Store = konfigurasi toko single user.
/// Hanya ada satu record Store di database SQLite.
/// StoreSettings di-embed langsung ke tabel Store via [Owned].
/// </summary>
public class Store : BaseEntity
{
    /// <summary>Nama toko, e.g. "Warung Berkah Jaya"</summary>
    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public StoreSettings Settings { get; set; } = new();
}

/// <summary>
/// Pengaturan toko — di-embed langsung ke tabel Store (EF Core Owned Entity).
/// </summary>
[Owned]
public class StoreSettings
{
    /// <summary>Default threshold stok rendah untuk produk baru</summary>
    public int DefaultLowStockThreshold { get; set; } = 5;

    /// <summary>Mata uang (default IDR)</summary>
    public string Currency { get; set; } = "IDR";

    /// <summary>Nama toko di header struk</summary>
    public string? ReceiptHeader { get; set; }

    /// <summary>Pesan di footer struk, e.g. "Terima kasih!"</summary>
    public string? ReceiptFooter { get; set; }
}
