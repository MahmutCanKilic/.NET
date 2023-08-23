using AutoMapper;
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
        private readonly IMapper mapper;
        public BusController(BusManager busManager, IMapper mapper)
        {
            this.busManager = busManager;
            this.mapper = mapper;
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(CreateBusDto busDto)
        {
            Bus bus = mapper.Map<Bus>(busDto);
            busManager.Add(bus);
            return Ok("eklendi");
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(CreateBusDto busDto)
        {
            Bus bus = mapper.Map<Bus>(busDto);
            busManager.Delete(bus);
            return Ok("silindi");
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(CreateBusDto busDto)
        {
            Bus bus = mapper.Map<Bus>(busDto);
            busManager.Update(bus);
            return Ok(bus);
        }

        [HttpPost(nameof(FindWithId))]
        public IActionResult FindWithId(CreateBusDto busBto)
        {
            Bus bus = mapper.Map<Bus>(busBto);

            Bus findedBus = busManager.FindWithId(bus);
            busBto = mapper.Map<CreateBusDto>(findedBus);
            return Ok(busBto);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            IEnumerable<CreateBusDto> busList = busManager.GetAll().Select(x => mapper.Map<CreateBusDto>(x));
            return Ok(busList);
        }
    }
}
