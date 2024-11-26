using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Context
{
    public class EF6Context : DbContext
    {

        public EF6Context(string name = "name=EF6Context") : base(name ?? "name=EF6Context")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookWithMoreColumns> BooksWithMoreColumns { get; set; }
    }

    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
    }

    public class BookWithMoreColumns
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ExtraColumnA { get; set; }
        public string ExtraColumnB { get; set; }
        public string ExtraColumnC { get; set; }
        public string ExtraColumnD { get; set; }
        public string ExtraColumnE { get; set; }
        public string ExtraColumnF { get; set; }
        public string ExtraColumnG { get; set; }
        public string ExtraColumnH { get; set; }
        public string ExtraColumnI { get; set; }
        public string ExtraColumnJ { get; set; }
        public string ExtraColumnK { get; set; }
    }

}
