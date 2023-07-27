using Data.Entity;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository
    {
        public void Insert(Product product)
        {
            MyContext db = new MyContext();//açılacak connection, database'e ulaşmak.
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            MyContext db= new MyContext();
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges ();
        }
        public Product FindWithId(int id)
        {
            MyContext db = new MyContext ();
            Product product = db.Products.Find(id);
            return product;
        }
        public void Update(Product product)
        {
            MyContext db = new MyContext();
            db.Products.Attach(product);
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public IEnumerable<Product> GetAll()
        {
            MyContext db = new MyContext();
               return db.Products.AsQueryable();
            
        }
    }
}
