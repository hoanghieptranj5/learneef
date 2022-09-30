using System.Security.Policy;
using Repositories.Models;
using Publisher = Repositories.Models.Publisher;

namespace Repositories.Helpers;

public class DbContextHelper
{
    public ApplicationDbContext DbContext { get; set; }

    public DbContextHelper(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public void InsertData()
    {
        DbContext.Database.EnsureCreated();

        var publisher = new Publisher()
        {
            Name = "Mariner Books"
        };

        DbContext.Books.Add(new Book
        {
            ISBN = "978-0544003415",
            Title = "The Lord of the Rings",
            Author = "J.R.R. Tolkien",
            Language = "English",
            Pages = 1216,
            Publisher = publisher
        });
        DbContext.Books.Add(new Book
        {
            ISBN = "978-0547247762",
            Title = "The Sealed Letter",
            Author = "Emma Donoghue",
            Language = "English",
            Pages = 416,
            Publisher = publisher
        });

        DbContext.SaveChanges();
    }
}