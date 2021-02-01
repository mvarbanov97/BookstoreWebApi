using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> books;

        public DbClient(IOptions<BookstoreDbConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            this.books = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);
        }

        public IMongoCollection<Book> GetBooksCollection()
        {
            return books;
        }
    }
}
