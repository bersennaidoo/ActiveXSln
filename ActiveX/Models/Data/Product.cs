using System.ComponentModel.DataAnnotations.Schema;

namespace ActiveX.Models.Data;

public class Product
{
    public long? ProductID { get; set; }

    public string Name { get; set; } = String.Empty;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }

    public string Category { get; set; } = String.Empty;
}