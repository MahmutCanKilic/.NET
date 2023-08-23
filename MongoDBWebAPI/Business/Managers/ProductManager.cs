using Data.Entity;
using DataAccess.Repos;

namespace Business.Managers
{
    public class ProductManager
    {
        private readonly ProductRepository repository;
        public ProductManager(ProductRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Product product)
        {
            repository.Add(product);
        }
        public void Update(Product product)
        {
            repository.Update(product);
        }
        public void Delete(Product product)
        {
            repository?.Delete(product);
        }
        public void GetAll()
        {
            repository.GetAll();
        }

    }
}