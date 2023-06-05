using Homework5._29.Data;
using Homework5._29.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homework5._29.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : SharedController
    {

        public UserController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpPost]
        [Route("adduser")]
        public void AddUser(SignupViewModel user)
        {
            var ur = new UserRepository(_connectionString);
            ur.AddUser(user, user.Password);
        }

        [HttpPost]
        [Route("login")]
        public User Login(LoginViewModel loginViewModel)
        {
            var ur = new UserRepository(_connectionString);
            var user = ur.Login(loginViewModel.Email, loginViewModel.Password);
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim("user", loginViewModel.Email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();
            return user;
        }
        [HttpGet]
        [Route("getcurrentuser")]
        public override User GetCurrentUser()
        {
            return base.GetCurrentUser();
        }
        [Authorize]
        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }
    }
}
