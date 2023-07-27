using Business;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IA _interface;

        public UserController(IA _inter)
        {
            _interface = _inter;
        }

        UserManager userManager;
        public UserController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public IActionResult GetUserById(int id)
        {
            User user = userManager.GetUserById(id);
            if (user != null)
            {
                return Ok(user);

            }
            return BadRequest();
        }

        
    }

    public interface IA
    {

    }

    public class B : IA
    {
        //mysql
    }

    public class C : IA
    {
        //sqlite
    }
}
