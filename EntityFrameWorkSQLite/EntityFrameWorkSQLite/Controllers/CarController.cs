using AutoMapper;
using Business.Manager;
using Data.Dto;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace EntityFrameWorkSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly CarManager carManager;
        public CarController(CarManager carManager, IMapper mapper)
        {
            this.mapper = mapper;
            this.carManager = carManager;
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(CreateCarDto carDto)
        {
            Car car = mapper.Map<Car>(carDto);

            carManager.Add(car);
            return Ok(carDto);
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(CreateCarDto carDto)
        {
            Car car = mapper.Map<Car>(carDto);
            carManager.Delete(car);
            return Ok("silindi");
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(CreateCarDto carDto)
        {
            Car car = mapper.Map<Car>(carDto);

            carManager.Update(car);
            return Ok(carDto);
        }

        [HttpPost(nameof(FindWithId))]
        public IActionResult FindWithId(CreateCarDto carDto)
        {
            Car car = mapper.Map<Car>(carDto);
            
            carDto = mapper.Map<CreateCarDto>(carManager.FindWithId(car));
            return Ok(carDto);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            IEnumerable<CreateCarDto> carList =  carManager.GetAll().Select(x => mapper.Map<CreateCarDto>(x));

            return Ok(carList);
        }
    }
}
