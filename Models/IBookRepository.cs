using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeBib.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Book Get(int id);
        void Delete(Book book);
        void Create(Book book);
    }
}
