using Data;
using Data.Entity;
using DataAccess.Interfaces;
using MongoDB.Driver;

namespace DataAccess.Repos
{
    public class ProductRepository : IRepository<Product>
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
        public async Task Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
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
        public async Task AddRange(List<Product> products)
        {
            await db.ProductsCollection.InsertManyAsync(products);
        }

    }
}