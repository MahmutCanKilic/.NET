using Data.Entity;
using DataAccess.Interfaces;
using DataAccess.Repository;
using System.Windows.Input;

namespace Business.Manager
{
    public class CarManager: IBusiness<Car>
    {
        private readonly CarRepository carRepository;
        public CarManager(CarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public void Add(Car car)
        {
            carRepository.Add(car);
        }
        public void Update(Car car)
        {
            carRepository.Update(car);
        }
        public void Delete(Car car)
        {
            carRepository.Delete(car);
        }
        public IEnumerable<Car> GetAll()
        {
            return carRepository.GetAll();
        }
        public Car FindWithId(Car car)
        {
            return carRepository.FindWithId(car);
        }
    }
}