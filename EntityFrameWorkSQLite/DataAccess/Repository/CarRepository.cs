using Data.Entity;
using DataAccess.Context;
using DataAccess.Interfaces;

namespace DataAccess.Repository
{
    public class CarRepository: IDataAccess<Car>
    {
        private readonly MyContext db;
        public CarRepository(MyContext db) 
        {
            this.db = db;
        }
        public void Add(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Delete(Car car)
        {
            db.Cars.Remove(car);
            db.SaveChanges();
        }

        public Car FindWithId(Car car)
        {
            return db.Cars.FirstOrDefault(c => c.ID == car.ID);
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars.AsQueryable();
        }

        public void Update(Car car)
        {
            //db.Attach(car);
            //db.Entry(car).Entity = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Cars.Update(car);
            db.SaveChanges();
        }
    }
}
