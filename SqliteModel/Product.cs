using Commons;

namespace SqliteModel;

/// <summary>
/// Produk / barang dagangan.
/// </summary>
public class Product : BaseEntity
{
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
    public bool IsLowStock => Stock.HasValue && Stock.Value <= LowStockThreshold;
}
