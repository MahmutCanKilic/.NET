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
    public class CustomerManager:IBusiness<Customer>
    {
        private readonly CustomerRepository customerRepository;
        public CustomerManager(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            customerRepository.Add(customer);
        }
        public void Update(Customer customer)
        {
            customerRepository.Update(customer);
        }
        public void Delete(Customer customer)
        {
            customerRepository.Delete(customer);
        }
        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }
        public Customer FindWithId(Customer customer)
        {
            return customerRepository.FindWithId(customer);
        }
    }
}
