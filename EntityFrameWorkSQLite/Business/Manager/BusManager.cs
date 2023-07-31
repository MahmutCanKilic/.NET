using Data.Entity;
using DataAccess.Interfaces;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class BusManager : IBusiness<Bus>
    {
        private readonly BusRepository busRepository;
        public BusManager(BusRepository busRepository)
        {
            this.busRepository = busRepository;
        }
        public void Add(Bus bus)
        {
            busRepository.Add(bus);
        }

        public void Delete(Bus bus)
        {
            busRepository.Delete(bus);
        }

        public Bus FindWithId(Bus bus)
        {
            return busRepository.FindWithId(bus);
        }

        public IEnumerable<Bus> GetAll()
        {
            return busRepository.GetAll();
        }

        public void Update(Bus bus)
        {
            busRepository.Update(bus);
        }
    }
}
