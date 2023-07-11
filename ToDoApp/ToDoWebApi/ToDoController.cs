using Business;
using Data;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ToDoWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        static ToDoBusiness toDoBusiness = new ToDoBusiness();
        
        [HttpGet("AllToDos")]
        public IActionResult GetToDos()
        {

            return Ok(toDoBusiness.All());
        }
        
        [HttpPost("AddToDo")]
        public IActionResult AddToDoPost([FromBody]ToDo toDo)
        {
            toDoBusiness.Add(toDo.Id, toDo.Description);
            return Ok($"{toDo.Id} / {toDo.Description} eklendi.");
        }
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            toDoBusiness.Delete(id);
            return Ok($"{id} silindi");
        }
        
        [HttpGet("FindID")]
        public IActionResult FindIdGet(int id)
        {
            toDoBusiness.FindId(id);
            return Ok($"{id}");
        }
        [HttpGet("FindDeteailed")]
        public IActionResult FindDetailedGet(ToDo toDo)
        {
            toDoBusiness.FindDetailed(toDo.Id, toDo.Description);
            return Ok($"Kayıt: {toDo.Id}   {toDo.Description}");
        }

        [HttpPatch("UpdateProduct")]
        public IActionResult PatchProducts(ToDo toDo)
        {
            toDoBusiness.Update(toDo.Id, toDo.Description);
            return Ok($"{toDo.Id} -> {toDo.Description}");
        }

        [HttpPut("PutProducts")]
        public IActionResult PutProducts(List<ToDo> toDoList)
        {
            toDoBusiness.UpdateAll(toDoList);
            return Ok($"güncellendi");
        }

    }

}
