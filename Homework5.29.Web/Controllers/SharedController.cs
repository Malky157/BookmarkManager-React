using Homework5._29.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework5._29.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        protected readonly string _connectionString;
        public SharedController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public virtual User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var ur = new UserRepository(_connectionString);
            return ur.GetByEmail(User.Identity.Name);
        }
    }
}
