using Data.Entity;
using DataAccess.Repository;

namespace Business
{
    public class ProductManager
    {
       public ProductRepository repository = new ProductRepository();
        public void Insert(Product product)
        {
            repository.Insert(product);
        }
        public void Delete(int id)
        {
            repository.Delete(id);
            
        }
        public void Update(Product product)
        {
            repository.Update(product);
        }
        public Product Find(int id)
        {
            return repository.FindWithId(id);
        }
        public IEnumerable<Product> GetAll()
        {
           return repository.GetAll();
        }
    }
}