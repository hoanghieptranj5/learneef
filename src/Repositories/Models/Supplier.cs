using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models;

public class Supplier
{
    [Column("id")]
    public int SupplierId { get; set; }

    [Column("company")]
    public string? CompanyName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("email_address")]
    public string? EmailAddress { get; set; }
}