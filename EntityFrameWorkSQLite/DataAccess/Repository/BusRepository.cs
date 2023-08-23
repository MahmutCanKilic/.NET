using Data.Entity;
using DataAccess.Context;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataAccess.Repository
{
    public class BusRepository : IDataAccess<Bus>
    {
        private readonly MyContext db;
        public BusRepository(MyContext db)
        {
            this.db = db;   
        }

        public void Add(Bus bus)
        {
            db.Buses.Add(bus);
            db.SaveChanges();
        }

        public void Delete(Bus bus)
        {
            db.Buses.Remove(bus);
            db.SaveChanges();
        }

        public Bus FindWithId(Bus bus)
        {
            return db.Buses.FirstOrDefault(b => b.CustomerID == bus.CustomerID);
        }

        public IEnumerable<Bus> GetAll()
        {
            return db.Buses.AsQueryable();
        }

        public void Update(Bus bus)
        {
            //db.Attach(bus);
            //db.Entry(bus).Entity = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Buses.Update(bus);
            db.SaveChanges();
        }
    }
}

