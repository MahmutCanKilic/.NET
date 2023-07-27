using Business.Managers;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager manager;
        public CategoryController(CategoryManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            manager.Add(category);
            return Ok($"{category}  eklendi");
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            string categoryText = category.ToString();
            manager.Delete(category);
            return Ok(categoryText);
        }
        [HttpGet]
        public IActionResult FindWithId(Category category)
        {
            return Ok(manager.FindWithId(category));
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            string categoryText = category.ToString();
            manager.Update(category);
            return Ok($"{categoryText} güncellendi: {category}");
        }
        [HttpGet]
        public IActionResult GetAll(Category category)
        {

            return Ok(manager.GetAll(category).ToList());
        }
    }
}
