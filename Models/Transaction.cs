using System.Text.Json.Serialization;
using System.Transactions;
using Commons;

namespace Models;

/// <summary>
/// Transaksi penjualan.
/// Setiap kali ada pembeli, user buat transaksi baru.
/// Item bisa dari produk yang sudah ada di database, atau produk baru (quick add).
/// </summary>
public class Transaction : BaseEntity
{
    [JsonPropertyName("type")] public string Id { get; set; } = "";
    
    /// <summary>Nomor transaksi auto-generate: TRX-20260312-001</summary>
    public string TransactionNumber { get; set; } = string.Empty;
 
    /// <summary>Daftar item yang dibeli</summary>
    public List<TransactionItem> Items { get; set; } = [];
 
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
 
    /// <summary>Catatan (opsional), e.g. "Pak Budi langganan"</summary>
    public string? Note { get; set; }
}

/// <summary>
/// Item dalam transaksi.
/// Menyimpan snapshot harga saat transaksi (tidak berubah walau harga produk berubah).
/// </summary>
public class TransactionItem
{
    /// <summary>ID produk (null jika quick add / produk belum di database)</summary>
    public string? ProductId { get; set; }
 
    /// <summary>Nama produk (snapshot)</summary>
    public string ProductName { get; set; } = string.Empty;
 
    /// <summary>Harga satuan saat transaksi (snapshot)</summary>
    public decimal UnitPrice { get; set; }
 
    /// <summary>Jumlah beli</summary>
    public int Quantity { get; set; } = 1;
 
    /// <summary>Subtotal item = UnitPrice × Quantity</summary>
    public decimal Subtotal => UnitPrice * Quantity;
}