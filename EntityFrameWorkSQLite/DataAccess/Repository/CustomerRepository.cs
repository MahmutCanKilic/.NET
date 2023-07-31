using Data.Entity;
using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomerRepository: IDataAccess<Customer>
    {
        private readonly MyContext db;
        public CustomerRepository(MyContext db)
        {
            this.db = db;
        }

        public void Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public Customer FindWithId(Customer customer)
        {
            return db.Customers.Find(customer.ID);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.AsQueryable();
        }

        public void Update(Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }
    }
}
