using System.ComponentModel.DataAnnotations.Schema;

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
    
    public virtual Category Category { get; set; }
}