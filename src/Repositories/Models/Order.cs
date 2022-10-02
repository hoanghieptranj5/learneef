using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public class Order
{
    public int Id { get; set; }
    [Column("employee_id")]
    public int EmployeeId { get; set; }
    
    [Column("customer_id")]
    public int CustomerId { get; set; }
    
    [ForeignKey("fk_orders_employees1")]
    public Employee Employee { get; set; }
    
    [ForeignKey("fk_orders_customers")]
    public Customer Customer { get; set; }
}