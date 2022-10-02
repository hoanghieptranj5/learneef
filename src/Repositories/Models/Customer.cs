namespace Repositories.Models;

public class Customer
{
    public int Id { get; set; }
    public string Company { get; set; }
    
    public virtual ICollection<Order> Orders { get; set; }
}