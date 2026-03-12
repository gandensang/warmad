using System.Text.Json.Serialization;
using Commons;

namespace Models;

/// <summary>
/// Ringkasan harian — di-generate otomatis atau on-demand.
/// Ini yang biasanya pemilik warung tulis di kertas:
/// "Hari ini dapat sekian, keluar sekian, sisa sekian"
/// 
/// Disimpan sebagai dokumen terpisah agar query dashboard cepat & hemat RU.
/// </summary>
public class DailySummary : BaseEntity
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
 
    /// <summary>Tanggal (format: "2026-03-12")</summary>
    public string Date { get; set; } = string.Empty;
 
    /// <summary>Total pemasukan dari penjualan</summary>
    public decimal TotalIncome { get; set; }
 
    /// <summary>Total pengeluaran</summary>
    public decimal TotalExpense { get; set; }
 
    /// <summary>Sisa kas = pemasukan - pengeluaran</summary>
    public decimal NetCash => TotalIncome - TotalExpense;
 
    /// <summary>Jumlah transaksi penjualan</summary>
    public int TransactionCount { get; set; }
 
    /// <summary>Breakdown pengeluaran per kategori</summary>
    public Dictionary<StaticExpenseCategory, decimal> ExpenseBreakdown { get; set; } = [];
 
    /// <summary>Top produk terlaris hari ini (max 5)</summary>
    public List<TopProductEntry> TopProducts { get; set; } = [];
}
/// <summary>
/// Entry produk terlaris
/// </summary>
public class TopProductEntry
{
    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }
 
    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = string.Empty;
 
    [JsonPropertyName("quantitySold")]
    public int QuantitySold { get; set; }
 
    [JsonPropertyName("totalRevenue")]
    public decimal TotalRevenue { get; set; }
}