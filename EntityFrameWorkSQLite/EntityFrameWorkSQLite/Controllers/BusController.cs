using Business.Manager;
using Data.Dto;
using Data.Entity;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace EntityFrameWorkSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly BusManager busManager;
        public BusController(BusManager busManager)
        {
            this.busManager = busManager;
        }

        [HttpPost("Add")]
        public IActionResult Add(CreateBusDto bus)
        {
            Bus newBus = new Bus
            {
                CustomerID = bus.CustomerID,
                Brand = bus.Brand,
                Name = bus.Name,
                Price = bus.Price
            };
            busManager.Add(newBus);
            return Ok(bus);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Bus bus)
        {
            busManager.Delete(bus);
            return Ok(bus);
        }

        [HttpPut("Update")]
        public IActionResult Update(CreateBusDto bus)
        {
            Bus newBus = new Bus
            {
                CustomerID = bus.CustomerID,
                Brand = bus.Brand,
                Name = bus.Name,
                Price = bus.Price
            };
            busManager.Update(newBus);
            return Ok("güncellendi");
        }

        [HttpPost("Find")]
        public IActionResult FindWithId(CreateBusDto bus)
        {
            Bus newBus = new Bus
            {
                CustomerID = bus.CustomerID,
                Brand = bus.Brand,
                Name = bus.Name,
                Price = bus.Price
            };
            CreateBusDto busDto = new CreateBusDto();
            busDto.CustomerID = newBus.CustomerID;
            busDto.Brand = newBus.Brand;
            busDto.Name = newBus.Name;
            busDto.Price = newBus.Price;
            busManager.FindWithId(newBus);

            return Ok(busDto);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            List<CreateBusDto> busList = new List<CreateBusDto>();
            foreach (var item in busManager.GetAll().ToList())
            {
                CreateBusDto busDto = new()
                {
                    Brand = item.Brand
                    , Name = item.Name
                    , Price = item.Price
                    , CustomerID = item.CustomerID
                };
                busList.Add(busDto);
            }
            return Ok(busList);
        }
    }
}
