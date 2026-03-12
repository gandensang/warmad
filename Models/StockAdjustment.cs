using System.Text.Json.Serialization;
using Commons;

namespace Models;

/// <summary>
/// Penyesuaian stok — semua perubahan stok di luar penjualan dicatat di sini.
/// Ini termasuk: stok masuk (belanja), koreksi, barang rusak, hilang, retur.
/// 
/// Alur:
/// 1. User belanja → catat Expense (BelanjaStok) → opsional buat StockAdjustment
/// 2. User cek stok fisik beda → buat StockAdjustment (Koreksi)
/// 3. Barang rusak/expired → buat StockAdjustment (Rusak)
/// </summary>
public class StockAdjustment : BaseEntity
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";

    /// <summary>Alasan penyesuaian</summary>
    public string Reason { get; set; } = StaticStockAdjustmentReason.StokMasuk;
 
    /// <summary>Daftar item yang disesuaikan</summary>
    public List<StockAdjustmentItem> Items { get; set; } = [];
 
    /// <summary>Catatan, e.g. "Kulakan dari Toko Jaya"</summary>
    public string? Note { get; set; }
 
    /// <summary>ID expense terkait (jika dari pencatatan belanja)</summary>
    public string? ExpenseId { get; set; }
}

/// <summary>
/// Item dalam stock adjustment
/// </summary>
public class StockAdjustmentItem
{
    /// <summary>ID produk</summary>
    public string ProductId { get; set; } = string.Empty;
 
    /// <summary>Nama produk (snapshot)</summary>
    public string ProductName { get; set; } = string.Empty;
 
    /// <summary>
    /// Jumlah perubahan (positif = tambah, negatif = kurang).
    /// Contoh: +24 (stok masuk), -3 (rusak), bisa juga angka absolut untuk koreksi.
    /// </summary>
    public int QuantityChange { get; set; }
 
    /// <summary>Stok sebelum penyesuaian (snapshot)</summary>
    public int? StockBefore { get; set; }
 
    /// <summary>Stok setelah penyesuaian (snapshot)</summary>
    public int? StockAfter { get; set; }
}