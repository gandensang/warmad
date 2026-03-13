namespace SqliteModel;

/// <summary>
/// Ringkasan harian — di-generate otomatis atau on-demand.
/// "Hari ini dapat sekian, keluar sekian, sisa sekian"
///
/// ExpenseBreakdown dan TopProducts disimpan di tabel terpisah dengan FK ke DailySummaryId.
/// </summary>
public class DailySummary : BaseEntity
{
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

    // Navigation properties
    public List<ExpenseCategoryBreakdown> ExpenseBreakdown { get; set; } = [];
    public List<TopProductEntry> TopProducts { get; set; } = [];
}

/// <summary>
/// Breakdown pengeluaran per kategori untuk satu hari — tabel terpisah.
/// Menggantikan Dictionary&lt;string, decimal&gt; agar kompatibel dengan relational DB.
/// </summary>
public class ExpenseCategoryBreakdown
{
    public int RowId { get; set; }

    /// <summary>FK ke DailySummary.Id</summary>
    public string DailySummaryId { get; set; } = string.Empty;

    /// <summary>Nama kategori, e.g. "BelanjaStok", "Operasional"</summary>
    public string Category { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    // Navigation property
    public DailySummary? DailySummary { get; set; }
}

/// <summary>
/// Entry produk terlaris untuk satu hari — tabel terpisah.
/// </summary>
public class TopProductEntry
{
    public int RowId { get; set; }

    /// <summary>FK ke DailySummary.Id</summary>
    public string DailySummaryId { get; set; } = string.Empty;

    public string? ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int QuantitySold { get; set; }
    public decimal TotalRevenue { get; set; }

    // Navigation property
    public DailySummary? DailySummary { get; set; }
}
