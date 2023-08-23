using MongoDB.Bson;
using MongoDB.Driver;
namespace Data.Entity
{
    public class Product
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}