using System.Text.Json.Serialization;
using Commons;

namespace Models;

public class Expense : BaseEntity
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    /// <summary>Kategori pengeluaran</summary>

    public string Category { get; set; } = StaticExpenseCategory.BelanjaStok;
 
    /// <summary>Jumlah uang keluar</summary>
    public decimal Amount { get; set; }
 
    /// <summary>Keterangan, e.g. "Kulakan ke Toko Jaya", "Bayar listrik bulan Maret"</summary>
    public string Description { get; set; } = string.Empty;
 
    /// <summary>
    /// ID stock adjustment terkait (jika kategori BelanjaStok dan user memilih update stok).
    /// Null jika tidak link ke stock adjustment.
    /// </summary>
    public string? StockAdjustmentId { get; set; }
 
    /// <summary>Apakah sudah di-link ke update stok</summary>
    [JsonIgnore]
    public bool HasStockUpdate => !string.IsNullOrEmpty(StockAdjustmentId);
}