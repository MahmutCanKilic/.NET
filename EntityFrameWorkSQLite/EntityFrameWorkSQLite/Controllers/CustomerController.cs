using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly CustomerManager customerManager;
        public CustomerController(CustomerManager customerManager, IMapper mapper)
        {
            this.mapper = mapper;
            this.customerManager = customerManager;
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(CreateCustomerDto customerDto)
        {
            Customer customer = mapper.Map<Customer>(customerDto);
            customerManager.Add(customer);
            return Ok(customerDto);
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(CreateCustomerDto customerDto)
        {
            Customer customer = mapper.Map<Customer>(customerDto);

            customerManager.Delete(customer);
            return Ok("Deleted");
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(CreateCustomerDto customerDto)
        {
            Customer customer = mapper.Map<Customer>(customerDto);

            customerManager.Update(customer);
            return Ok(customerDto);
        }

        [HttpPost(nameof(FindWithId))]
        public IActionResult FindWithId(CreateCustomerDto customerDto)
        {
            Customer customer = mapper.Map<Customer>(customerDto);

            customerDto = mapper.Map<CreateCustomerDto>(customerManager.FindWithId(customer));
            return Ok(customerDto);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            IEnumerable<CreateCustomerDto> customerList = customerManager.GetAll()
                        .Select(customer => mapper.Map<CreateCustomerDto>(customer));

            return Ok(customerList);
        }
    }
}
