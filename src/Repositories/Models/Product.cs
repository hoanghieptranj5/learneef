using System.ComponentModel.DataAnnotations.Schema;
using MySqlX.XDevAPI;

namespace Repositories.Models;

public class Product
{
    [Column("id")]
    public int ProductID { get; set; }
    
    [Column("product_name")]
    public string ProductName { get; set; }
    
    [Column("list_price")]
    public Decimal? UnitPrice { get; set; }
    
    public bool Discontinued { get; set; }
    
    [Column("category")]
    public string Category { get; set; }
    
    [Column("supplier_ids")]
    public string SupplierIds { get; set; }
}