using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreApiSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Business business = new Business();
        //[HttpGet]
        //public IActionResult Get(string message)
        //{
        //    message = business.All(1);
        //    return Ok($"received message: {message}");
        //}
        [HttpGet("Get")]
        public IActionResult Get()
        {
            int degisken = 5;
            Console.WriteLine($"degiskenin degeri: {degisken}");
            List<int> result = business.All();
            return BadRequest(result);
        }

        [HttpGet("GetName")]
        public IActionResult GetName()
        {
            string result = "Can";
            return Ok(result);
        }

        [HttpGet("SayHello")]
        public IActionResult SayHello([FromBody] Person person)
        {
            string result = $"Ss";
            return Ok(result);
        }
        [HttpPost]
        public IActionResult PostMethod([FromBody] Person person)
        {
            return Ok($"{person.Name} kaydedildi");
        }

        static int id2 = 5;
        [HttpGet]
        public IActionResult GetMethod2()
        {
            
            return Ok($"id: {id2}");
        }
        [HttpPut("{id}")]
        public IActionResult PutMethod(int id)
        {
            id2 = id;
            return Ok($"id: {id2}");
        }

        [HttpGet("Yeni id")]
        public IActionResult NewId()
        {
            return Ok($"yeni id: {id2}");
        }
    }

    public class Person
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
