using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public class Employee
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("company")]
    public string Company { get; set; }
    
    public virtual ICollection<Order> Orders { get; set; }
}