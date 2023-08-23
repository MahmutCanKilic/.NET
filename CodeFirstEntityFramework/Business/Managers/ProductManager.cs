using Data.NewFolder;
using DataAccess.Repository;
using System.Security.Cryptography.X509Certificates;

namespace Business.Managers
{
    public class ProductManager
    {
        ProductRepository repository = new ProductRepository();

        public IEnumerable<Product> Find(Product product)
        {
            return repository.Find(product);
        }
        public async Task Add(Product product)
        {
            await repository.Add(product);
        }
        public async Task Delete(Product product)
        {
            await repository.Delete(product);
        }
        public async Task UpdateAsync(Product product)
        {
            await repository.UpdateAsync(product);
            
        }
        public void UpdateOneThread(Product product)
        {
            repository.UpdateOneThread(product);
        }
        public void UpdateSemaphore(Product product)
        {
            repository.UpdateSemaphore(product);
        }
        public Task<List<Product>> GetAll()
        {
            return repository.GetAll();
        }
    }
}