using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> books;

        public BookServices(IDbClient dbClient)
        {
            this.books = dbClient.GetBooksCollection();
        }

        public Book AddBook(Book book)
        {
            this.books.InsertOne(book);
            return book;
        }

        public void DeleteBook(string id)
        {
            books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id)
        {
            return this.books.Find(book => book.Id == id).First();
        }

        public IEnumerable<Book> GetBooks()
        {
            return this.books.Find(book => true).ToList();
        }

        public Book UpdateBook(Book book)
        {
            this.GetBook(book.Id);

            this.books.ReplaceOne(b => b.Id == book.Id, book);
            return book;
        }
    }

}
