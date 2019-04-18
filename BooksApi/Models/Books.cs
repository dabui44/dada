using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string BookName { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
