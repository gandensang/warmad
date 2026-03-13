using Commons;

namespace SqliteModel;

/// <summary>
/// Transaksi penjualan.
/// Items disimpan di tabel terpisah (TransactionItem) dengan FK ke TransactionId.
/// </summary>
public class Transaction : BaseEntity
{
    /// <summary>Nomor transaksi auto-generate: TRX-20260312-001</summary>
    public string TransactionNumber { get; set; } = string.Empty;

    /// <summary>Total sebelum diskon</summary>
    public decimal Subtotal { get; set; }

    /// <summary>Diskon keseluruhan (opsional)</summary>
    public decimal Discount { get; set; }

    /// <summary>Total yang harus dibayar</summary>
    public decimal GrandTotal { get; set; }

    /// <summary>Uang yang diterima dari pembeli</summary>
    public decimal AmountPaid { get; set; }

    /// <summary>Kembalian</summary>
    public decimal Change { get; set; }

    /// <summary>Metode pembayaran</summary>
    public string PaymentMethod { get; set; } = StaticPaymentMethod.Cash;

    /// <summary>Status: Completed / Voided</summary>
    public string Status { get; set; } = StaticTransactionStatus.Completed;

    /// <summary>Catatan (opsional)</summary>
    public string? Note { get; set; }

    // Navigation property
    public List<TransactionItem> Items { get; set; } = [];
}

/// <summary>
/// Item dalam transaksi — tabel terpisah.
/// Menyimpan snapshot harga saat transaksi.
/// </summary>
public class TransactionItem
{
    public int RowId { get; set; }

    /// <summary>FK ke Transaction.Id</summary>
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>ID produk (null jika quick add)</summary>
    public string? ProductId { get; set; }

    /// <summary>Nama produk (snapshot)</summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>Harga satuan saat transaksi (snapshot)</summary>
    public decimal UnitPrice { get; set; }

    /// <summary>Jumlah beli</summary>
    public int Quantity { get; set; } = 1;

    /// <summary>Subtotal item = UnitPrice × Quantity</summary>
    public decimal Subtotal => UnitPrice * Quantity;

    // Navigation property
    public Transaction? Transaction { get; set; }
}
