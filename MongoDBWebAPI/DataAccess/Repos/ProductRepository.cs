using Data;
using Data.Entity;
using MongoDB.Driver;

namespace DataAccess.Repos
{
    public class ProductRepository
    {
        private readonly DatabaseContext db;

        public ProductRepository(DatabaseContext dbContext)
        {
            db = dbContext;
        }
        public async Task Add(Product product)
        {
            await db.ProductsCollection.InsertOneAsync(product);
        }
        public async Task Delete(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            await db.ProductsCollection.DeleteOneAsync(filter);
        }
        public async Task Update(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, product.Id);
            var update = Builders<Product>.Update
                .Set(x => x.Name, product.Name)
                .Set(x => x.Price, product.Price)
                .Set(x => x.Description, product.Description);

            var result = await db.ProductsCollection.UpdateOneAsync(filter, update);
        }
        public async Task<List<Product>> GetAll()
        {
            var filter = Builders<Product>.Filter.Empty;
            var result = await db.ProductsCollection.Find(filter).ToListAsync();

            return result;
        }
    }
}