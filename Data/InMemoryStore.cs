using Session1LinqApp.Models;

namespace Session1LinqApp.Data;

public static class InMemoryStore
{
    public static List<Author> Authors = new();
    public static List<Book> Books = new();
    public static List<Tag> Tags = new();

    static InMemoryStore()
    {
        Seed();
    }

    public static void Seed()
    {
        // Authors
        Authors.AddRange(new List<Author>
        {
            new Author { Id = 1, Name = "Author A" },
            new Author { Id = 2, Name = "Author B" },
            new Author { Id = 3, Name = "Author C" }
        });

        // Books
        Books.AddRange(new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Year = 2020, PageCount = 300, AuthorId = 1 },
            new Book { Id = 2, Title = "Book 2", Year = 2021, PageCount = 600, AuthorId = 1 },
            new Book { Id = 3, Title = "Book 3", Year = 2019, PageCount = 150, AuthorId = 2 },
            new Book { Id = 4, Title = "Book 4", Year = 2022, PageCount = 700, AuthorId = 2 },
            new Book { Id = 5, Title = "Book 5", Year = 2018, PageCount = 250, AuthorId = 3 },
            new Book { Id = 6, Title = "Book 6", Year = 2023, PageCount = 800, AuthorId = 3 },
            new Book { Id = 7, Title = "Book 7", Year = 2020, PageCount = 400, AuthorId = 1 },
            new Book { Id = 8, Title = "Book 8", Year = 2021, PageCount = 500, AuthorId = 2 }
        });

        // Tags
        Tags.AddRange(new List<Tag>
        {
            new Tag { Id = 1, Name = "Tech" },
            new Tag { Id = 2, Name = "Science" },
            new Tag { Id = 3, Name = "Fiction" },
            new Tag { Id = 4, Name = "History" }
        });

        // BookTags (6 links)
        Books[0].BookTags.Add(new BookTag { BookId = 1, TagId = 1 });
        Books[1].BookTags.Add(new BookTag { BookId = 2, TagId = 2 });
        Books[2].BookTags.Add(new BookTag { BookId = 3, TagId = 3 });
        Books[3].BookTags.Add(new BookTag { BookId = 4, TagId = 4 });
        Books[4].BookTags.Add(new BookTag { BookId = 5, TagId = 1 });
        Books[5].BookTags.Add(new BookTag { BookId = 6, TagId = 2 });
    }
}