using Data.Entity;
using MongoDB.Driver;

namespace Data
{
    public class DbSettings
    {
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";
        public string DbName { get; set; } = "ProductsDb";
        public string ProductsCollectionName { get; set; } = "Products";
    }

    public class DatabaseContext
    {
        public IMongoCollection<Product> ProductsCollection { get; set; }

        public DatabaseContext(DbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DbName);
            ProductsCollection = database.GetCollection<Product>(settings.ProductsCollectionName);
        }
    }
}
