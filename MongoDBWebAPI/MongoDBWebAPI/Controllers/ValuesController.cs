using Business.Managers;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProductManager manager;
        public ValuesController(ProductManager manager)
        {
                this.manager = manager;
        }
        [HttpPost(nameof(Add))]
        IActionResult Add(Product product)
        {
            return Ok("eklendi");
        }
        [HttpDelete(nameof(Delete))]   
        IActionResult Delete(Product product)
        {
            return Ok("silindi");
        }
        [HttpPut(nameof(Update))]      
        IActionResult Update(Product product)
        {
            return Ok("Güncellendi");
        }
        [HttpGet(nameof(GetAll))]
        IActionResult GetAll()
        {
            return Ok(GetAll());
        }
        
    }
}
