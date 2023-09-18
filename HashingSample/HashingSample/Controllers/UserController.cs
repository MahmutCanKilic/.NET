using Business.Managers;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Buffers;

namespace HashingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager userManager;
        public UserController(UserManager manager)
        {
            userManager = manager;
        }

        [HttpPost(nameof(LogIn))]
        public IActionResult LogIn(User user)
        {
            bool logInInfo = userManager.LogIn(user);
            return Ok(logInInfo);
        }

        [HttpPost(nameof(SignIn))]
        public IActionResult SignIn(User user)
        {
            userManager.SignIn(user);
            return Ok("Kayıt başarılı");
        }

        [HttpGet(nameof(GetAllUsers))]
        public IActionResult GetAllUsers()
        {
            return Ok(userManager.GetAll());
        }

    }
}

