using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeBib.Models
{
    public class BookInMemoryRepository : IBookRepository
    {
        private List<Book> books;

        public BookInMemoryRepository()
        {
            this.books = new List<Book>();
            Create(new Book { ISBN = "ISBN9027469385", Title = "In de ban van de ring", Author = "J.R.R. Tolkien", PublicationYear = 1997, Type = BookType.FICTION });
            Create(new Book { ISBN = "ISBN9789400407930", Title = "Sapiens", Author = "Yuval Noah Harari", PublicationYear = 2014, Type = BookType.NONFICTION });
            Create(new Book { ISBN = "ISBN9789024576791", Title = "Oorsprong", Author = "Dan Brown", PublicationYear = 2017, Type = BookType.FICTION });
            Create(new Book { ISBN = "ISBN9780744015423", Title = "Diablo III - Reaper of souls", Author = "Doug Walsh & Thom Denick", PublicationYear = 2014, Type = BookType.NONFICTION });
            Create(new Book { ISBN = "ISBN9780006479888", Title = "A game of thrones", Author = "George R.R. Martin", PublicationYear = 1996, Type = BookType.FICTION });
            Create(new Book { ISBN = "ISBN9781338216660", Title = "Harry potter and the cursed child", Author = "J.K. Rowling", PublicationYear = 2017, Type = BookType.FICTION });
            Create(new Book { ISBN = "ISBN9781509301041", Title = "Microsoft visual c# step by step", Author = "John Sharp", PublicationYear = 2015, Type = BookType.NONFICTION });
            Create(new Book { ISBN = "ISBN9789463932677", Title = "Bekend & Bescheiden", Author = "Xander De Rycke", PublicationYear = 2020, Type = BookType.NONFICTION });
        }

        public Book Get(int id)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public IQueryable<Book> GetAll()
        {
            return books.AsQueryable();
        }
        public void Delete(Book book)
        {
            this.books.Remove(book);
        }
        public void Create(Book book)
        {
            int max = 1;
            foreach (Book b in books)
            {
                if (b.Id > max)
                {
                    max = b.Id;
                }
            }
            book.Id = max + 1;
            books.Add(book);
        }
    }
}
