using Commons;

namespace SqliteModel;

/// <summary>
/// Penyesuaian stok — semua perubahan stok di luar penjualan.
/// Items disimpan di tabel terpisah (StockAdjustmentItem) dengan FK ke StockAdjustmentId.
/// </summary>
public class StockAdjustment : BaseEntity
{
    /// <summary>Alasan penyesuaian</summary>
    public string Reason { get; set; } = StaticStockAdjustmentReason.StokMasuk;

    /// <summary>Catatan, e.g. "Kulakan dari Toko Jaya"</summary>
    public string? Note { get; set; }

    /// <summary>ID expense terkait (jika dari pencatatan belanja)</summary>
    public string? ExpenseId { get; set; }

    // Navigation property
    public List<StockAdjustmentItem> Items { get; set; } = [];
}

/// <summary>
/// Item dalam stock adjustment — tabel terpisah.
/// </summary>
public class StockAdjustmentItem
{
    public int RowId { get; set; }

    /// <summary>FK ke StockAdjustment.Id</summary>
    public string StockAdjustmentId { get; set; } = string.Empty;

    /// <summary>ID produk</summary>
    public string ProductId { get; set; } = string.Empty;

    /// <summary>Nama produk (snapshot)</summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Jumlah perubahan (positif = tambah, negatif = kurang).
    /// Contoh: +24 (stok masuk), -3 (rusak).
    /// </summary>
    public int QuantityChange { get; set; }

    /// <summary>Stok sebelum penyesuaian (snapshot)</summary>
    public int? StockBefore { get; set; }

    /// <summary>Stok setelah penyesuaian (snapshot)</summary>
    public int? StockAfter { get; set; }

    // Navigation property
    public StockAdjustment? StockAdjustment { get; set; }
}
