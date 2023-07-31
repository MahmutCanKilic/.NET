using Business.Manager;
using Data.Dto;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManager customerManager;
        public CustomerController(CustomerManager customerManager)
        {
                this.customerManager = customerManager;
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(CreateCustomerDto customerDto)
        {
            Customer customer = new()
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                City = customerDto.City,
                
            };
            customerManager.Add(customer);
            return Ok(customerDto);
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(CreateCustomerDto customerDto)
        {
            Customer customer = new()
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                City = customerDto.City,
            };
            customerManager.Delete(customer);
            return Ok("Deleted");
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(CreateCustomerDto customerDto)
        {
            Customer customer = new()
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                City = customerDto.City,
                
            };
            customerManager.Update(customer);
            return Ok(customerDto);
        }

        [HttpPost(nameof(FindWithId))]
        public IActionResult FindWithId(CreateCustomerDto customerDto)
        {
            Customer customer = new()
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
                City = customerDto.City,

            };
            customerManager.FindWithId(customer);
            return Ok(customer);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<CreateCustomerDto> customerList = new List<CreateCustomerDto>();
            foreach (var item in customerManager.GetAll().ToList())
            {
                CreateCustomerDto customerDto = new()
                {
                    Name = item.Name,
                    Address = item.Address,
                    City = item.City,
                };
                customerList.Add(customerDto);
            }

            return Ok(customerList);
        }
    }
}
