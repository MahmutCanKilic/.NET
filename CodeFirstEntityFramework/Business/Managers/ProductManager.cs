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
        public void Add(Product product)
        {
            repository.Add(product);
        }
        public void Delete(Product product)
        {
            repository.Delete(product);
        }
        public void Update(Product product)
        {
            repository.Update(product);
        }
        public List<Product> GetAll()
        {
            return repository.GetAll();
        }
    }
}