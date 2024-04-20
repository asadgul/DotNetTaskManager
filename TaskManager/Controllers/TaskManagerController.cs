using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.DbModels;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly Databaseconfig _databaseconfig;
        private IUserAuthenticate userAuthenticate;
        public TaskManagerController(Databaseconfig databaseconfig, IUserAuthenticate userAuthenticate)
        {
            _databaseconfig = databaseconfig;
            this.userAuthenticate = userAuthenticate;
        }
        [HttpGet("GetProjectsList")]
        public async Task<IActionResult> GetProjectlist()
        {
            return Ok(await _databaseconfig.ProjectLists.ToListAsync());
        }

        [HttpGet("GetData")]
        public async Task<IActionResult> GetData()
        {
            var lis = await _databaseconfig.projects.ToListAsync();
            return Ok(lis);
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            var user = await userAuthenticate.AuthenticateUser(loginViewModel);
            if (user == null)
            {
                return BadRequest(string.Empty);
            }
            return Ok(user);
        }
    }
}
