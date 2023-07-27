using Data.NewFolder;
using DataAccess.Context;

namespace DataAccess.Repository
{
    public class ProductRepository
    {
        MyContext db = new MyContext();

        public IEnumerable<Product> Find(Product product)
        {
            return db.Products.Where(x => x.Id == product.Id || x.Name == product.Name);
        }
        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void Delete(Product product)
        {
            db.Remove(Find(product));
            db.SaveChanges();
        }
        public void Update(Product product)
        {
            db.Attach(product);
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }
    }
}