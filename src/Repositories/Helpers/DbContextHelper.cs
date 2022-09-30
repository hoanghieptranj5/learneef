using System.Security.Policy;
using Repositories.Models;
using Publisher = Repositories.Models.Publisher;

namespace Repositories.Helpers;

public static class DbContextHelper
{
    public static void InsertData()
    {
        using var context = new ApplicationDbContext();
        context.Database.EnsureCreated();

        var publisher = new Publisher()
        {
            Name = "Mariner Books"
        };

        context.Books.Add(new Book
        {
            ISBN = "978-0544003415",
            Title = "The Lord of the Rings",
            Author = "J.R.R. Tolkien",
            Language = "English",
            Pages = 1216,
            Publisher = publisher
        });
        context.Books.Add(new Book
        {
            ISBN = "978-0547247762",
            Title = "The Sealed Letter",
            Author = "Emma Donoghue",
            Language = "English",
            Pages = 416,
            Publisher = publisher
        });

        context.SaveChanges();
    }
}