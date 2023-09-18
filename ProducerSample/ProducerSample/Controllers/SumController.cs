using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProducerSample.Services;

namespace ProducerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumController : ControllerBase
    {
        private readonly RabbitMQService _rabbitmqService;
        public SumController(RabbitMQService rabbitmqService)
        {
            _rabbitmqService = rabbitmqService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SumModel sumModel)
        {
            _rabbitmqService.SendMessage(sumModel);
            return Ok();
        }
    }
}
