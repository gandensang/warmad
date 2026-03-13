using Commons;

namespace SqliteModel;

public class Expense : BaseEntity
{
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
    public bool HasStockUpdate => !string.IsNullOrEmpty(StockAdjustmentId);
}
