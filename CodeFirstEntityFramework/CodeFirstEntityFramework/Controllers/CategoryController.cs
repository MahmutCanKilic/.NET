using Business.Managers;
using Data.Entity;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly CategoryManager manager;
        public CategoryController(CategoryManager manager)
        {
            this.manager = manager;
        }
        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            manager.Add(category);
            return Ok($"{category}  eklendi");
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Category category)
        {
            string categoryText = category.ToString();
            manager.Delete(category);
            return Ok(categoryText);
        }
        [HttpPost("Find")]
        public IActionResult FindWithId(Category category)
        {
            return Ok(manager.FindWithId(category));
        }
        [HttpPut("Update")]
        public IActionResult Update(Category category)
        {
            string categoryText = category.ToString();
            manager.Update(category);
            return Ok($"{categoryText} güncellendi: {category}");
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(manager.GetAll().ToList());
        }
    }
}
