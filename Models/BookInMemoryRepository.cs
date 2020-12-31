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
            books.Add(new Book { Id = 1, ISBN = "ISBN9027469385", Title = "In de ban van de ring", Author = "J.R.R. Tolkien", PublicationYear = 1997, Type = BookType.FICTION });
            books.Add(new Book { Id = 2, ISBN = "ISBN9789400407930", Title = "Sapiens", Author = "Yuval Noah Harari", PublicationYear = 2014, Type = BookType.NONFICTION });
            books.Add(new Book { Id = 3, ISBN = "ISBN9789024576791", Title = "Oorsprong", Author = "Dan Brown", PublicationYear = 2017, Type = BookType.FICTION });
            books.Add(new Book { Id = 4, ISBN = "ISBN9780744015423", Title = "Diablo III - Reaper of souls", Author = "Doug Walsh & Thom Denick", PublicationYear = 2014, Type = BookType.NONFICTION });
            books.Add(new Book { Id = 5, ISBN = "ISBN9780006479888", Title = "A game of thrones", Author = "George R.R. Martin", PublicationYear = 1996, Type = BookType.FICTION });
            books.Add(new Book { Id = 6, ISBN = "ISBN9781338216660", Title = "Harry potter and the cursed child", Author = "J.K. Rowling", PublicationYear = 2017, Type = BookType.FICTION });
            books.Add(new Book { Id = 7, ISBN = "ISBN9781509301041", Title = "Microsoft visual c# step by step", Author = "John Sharp", PublicationYear = 2015, Type = BookType.NONFICTION });
            books.Add(new Book { Id = 8, ISBN = "ISBN9789463932677", Title = "Bekend & Bescheiden", Author = "Xander De Rycke", PublicationYear = 2020, Type = BookType.NONFICTION });
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
    }
}
