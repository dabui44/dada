using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using BooksApi.Models;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Books> _books;

        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _books = database.GetCollection<Books>("Books");
        }

        public List<Books> Get()
        {
            return _books.Find(books => true).ToList();
        }

        public Books Get(string id)
        {
            return _books.Find<Books>(book => book.Id == id).FirstOrDefault();
        }
        public Books Create(Books books)
        {
            _books.InsertOne(books);
            return books;
        }
        public void Update(string id, Books bookIn)
        {
            _books.ReplaceOne(book => book.Id == id, bookIn);
        }
        public void Remove(Books bookIn)
        {
            _books.DeleteOne(book => book.Id == bookIn.Id);
        }
        public void Remove(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}
