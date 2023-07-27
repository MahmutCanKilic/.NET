using Business.Managers;
using Data.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductManager productManager = new ProductManager();
        [HttpPost("Find")]
        public IActionResult Find(Product product)
        {
            return Ok(productManager.Find(product).ToList());
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            productManager.Add(product);
            return Ok($"{product} eklendi.");
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Product product)
        {
            string productText = $"{product} silindi.";
            productManager.Delete(product);
            return Ok(productText);
        }
        [HttpPut("Update")]
        public IActionResult Update(Product product)
        {
            productManager.Update(product);
            return Ok($"{product} -> güncel product");
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(productManager.GetAll());
        }
    }
}
