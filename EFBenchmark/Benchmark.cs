using EF6Context;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace EFBenchmark
{
    [SimpleJob(RunStrategy.ColdStart,iterationCount:10,warmupCount:1)]
    public class Benchmark
    {
        public Benchmark()
        {
            
        }

        [ParamsSource(nameof(ConnectionNames))]
        public string ConnName { get; set; }


        /// <summary>
        /// Converts the arguments into name=ConnectionString format
        /// </summary>
        /// <param name="names"></param>
        public static void SetConnectionNames(string[] names)
        {
            if (names == null || names.Length==0) return;

            ConnectionNames = names
                .Where(name=>!string.IsNullOrEmpty(name))
                .Select(name => $"name={name}");
        }

        public static IEnumerable<string> ConnectionNames { get; private set; } = new[] { "name=EF6Context" };

        [GlobalSetup]
        public void AddBooks()
        {
            Console.WriteLine($"ConnName={ConnName}");
            using (var ef = new EF6Context.EF6Context(ConnName))
            {
                if (ef.Books.Any()) return;

                var random = new Random();
                var titles = new[] { "The Great Gatsby", "1984", "To Kill a Mockingbird", "Pride and Prejudice", "The Catcher in the Rye" };
                var authors = new[] { "F. Scott Fitzgerald", "George Orwell", "Harper Lee", "Jane Austen", "J.D. Salinger" };
                var prices = new[] { 7.99m, 8.99m, 9.99m, 10.99m, 11.99m };

                for (int i = 0; i < 50; i++)
                {
                    var title = titles[random.Next(titles.Length)];
                    var author = authors[random.Next(authors.Length)];
                    var price = prices[random.Next(prices.Length)];

                    ef.Books.Add(new Book { Title = title, Author = author, Price = price });
                    ef.BooksWithMoreColumns.Add(new BookWithMoreColumns() { Title = title, Author = author, Price = price });
                }

                ef.SaveChanges();
            }
        }

        [Benchmark(Description = "Simple Book")]
        public void GetBookCount()
        {
            Console.WriteLine($"ConnName={ConnName}");
            List<Book> books;
            using (var ef = new EF6Context.EF6Context(ConnName))
            {

                books = ef.Books.ToList();

            }
        }


        [Benchmark(Description = "Book with More Columns")]
        public void GetBookCartControlCount()
        {
            List<EF6Context.BookWithMoreColumns> books;
            using (var ef = new EF6Context.EF6Context(ConnName))
            {

                books = ef.BooksWithMoreColumns.ToList();

            }
        }
    }
}