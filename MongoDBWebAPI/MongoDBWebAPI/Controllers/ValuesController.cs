using Business.Managers;
using Data.Dto;
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
        public IActionResult Add(ProductCreateDto productCreateDto)
        {
            manager.Add(productCreateDto);
            return Ok("eklendi");
        }
        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(string id)
        {
            manager.Delete(id);
            return Ok("silindi");
        }
        [HttpPut(nameof(Update))]
        public IActionResult Update(ProductUpdateDto productUpdateDto)
        {
            manager.Update(productUpdateDto);
            return Ok("Güncellendi");
        }
        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var result = await manager.GetAll();
            return Ok(result);
        }

    }
}
