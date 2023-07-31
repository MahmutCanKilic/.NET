using Business.Manager;
using Data.Dto;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarManager carManager;
        public CarController(CarManager carManager)
        {
            this.carManager = carManager;
        }

        [HttpPost("Add")]
        public IActionResult Add(CreateCarDto carDto)
        {
            Car car = new()
            {
                CarType = carDto.CarType,
                Name = carDto.Name,
                Price = carDto.Price,
                speed = carDto.speed,
                CustomerID = carDto.CustomerID,
            };
            carManager.Add(car);
            return Ok(carDto);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(CreateCarDto carDto)
        {
            Car car = new()
            {
                CarType = carDto.CarType,
                Name = carDto.Name,
                Price = carDto.Price,
                speed = carDto.speed,
                CustomerID = carDto.CustomerID,
            };
            carManager.Delete(car);
            return Ok("silindi");
        }

        [HttpPut("Update")]
        public IActionResult Update(CreateCarDto carDto)
        {
            Car car = new()
            {
                CarType = carDto.CarType,
                Name = carDto.Name,
                Price = carDto.Price,
                speed = carDto.speed,
                CustomerID = carDto.CustomerID,
            };
            carManager.Update(car);
            return Ok(carDto);
        }

        [HttpPost("Find")]
        public IActionResult FindWithId(CreateCarDto carDto)
        {
            Car car = new()
            {
                CarType = carDto.CarType,
                Name = carDto.Name,
                Price = carDto.Price,
                speed = carDto.speed,
                CustomerID = carDto.CustomerID,
            };
            carManager.FindWithId(car);
            return Ok(carDto);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            List<CreateCarDto> carList = new List<CreateCarDto>();
            foreach (var item in carManager.GetAll().ToList())
            {
                CreateCarDto car = new()
                {
                    CarType = item.CarType,
                    Name = item.Name,
                    Price = item.Price,
                    speed = item.speed,
                    CustomerID = item.CustomerID,
                };
                carList.Add(car);

            }
            return Ok(carList);
        }
    }
}
