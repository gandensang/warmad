using System.Text.Json.Serialization;
using Commons;

namespace Models;

/// <summary>
/// Produk / barang dagangan.
/// Desain seminimal mungkin:
/// - Nama & harga jual WAJIB
/// - Stok, harga modal, barcode OPSIONAL
/// - User bisa tambah produk cepat saat transaksi (cukup nama + harga)
/// </summary>
public class Product : BaseEntity
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    
    /// <summary>Nama produk, e.g. "Indomie Goreng"</summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>Harga jual satuan</summary>
    public decimal Price { get; set; }
 
    /// <summary>Harga modal/beli (opsional, untuk hitung margin)</summary>
    public decimal? CostPrice { get; set; }
 
    /// <summary>Stok saat ini (null = tidak tracking stok)</summary>
    public int? Stock { get; set; }
 
    /// <summary>Batas stok minimum untuk alert</summary>
    public int LowStockThreshold { get; set; } = 5;
 
    /// <summary>Satuan: pcs, pack, kg, dll</summary>
    public string Unit { get; set; } = StaticProductUnit.Pcs;
 
    /// <summary>Barcode (opsional, untuk scan)</summary>
    public string? Barcode { get; set; }
 
    /// <summary>Kategori sederhana (opsional), e.g. "Minuman", "Rokok"</summary>
    public string? Category { get; set; }
 
    /// <summary>Cek apakah stok di bawah threshold</summary>
    [JsonIgnore]
    public bool IsLowStock => Stock.HasValue && Stock.Value <= LowStockThreshold;
}