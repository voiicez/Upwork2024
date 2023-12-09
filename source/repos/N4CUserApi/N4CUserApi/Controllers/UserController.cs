using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace N4CUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        [Route("/api/[controller]/CreateUser")] //Birden fazla POST çağrısı için Route veriyoruz.
        public Task<IdentityResult> Create(IdentityUser user,string password)
        {
            return _userService.CreateAsync(user,password);
        }

        [HttpGet]
        [Route("/api/[controller]/GetByUserEmail/{email}")] //Birden fazla GET çağrısı için Route veriyoruz. Sonunda string bir parametre bekliyorsak /{parametre}
        public Task<IdentityUser> GetByUserEmail(string email)
        {
            return _userService.FindByEmailAsync(email);
        }
        [HttpDelete]
        [Route("/api/[controller]/DeleteUser")]
        public Task<IdentityResult> Delete(IdentityUser user)
        {
            return _userService.DeleteAsync(user);
        }
        
    }
}
