using Business;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductManager productManager = new ProductManager();
        [HttpPost("Insert")]
        public IActionResult Insert(Product product)
        {
            productManager.Insert(product);

            return Ok("Eklendi");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            productManager.Delete(id);
            return Ok($"{productManager.Find(id)} silindi");
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(productManager.GetAll());
        }
        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            return Ok(productManager.Find(id));
        }
        [HttpPut("Update")]
        public IActionResult Update(Product product)
        {
            

            productManager.Update(product);

            return Ok();
        }

    }
}
