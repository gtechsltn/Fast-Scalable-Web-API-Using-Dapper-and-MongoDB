using FastScalableApi.Models;
using FastScalableApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastScalableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("sql")]
        public async Task<IActionResult> GetSqlUsers()
        {
            var users = await _userService.GetSqlUsersAsync();
            return Ok(users);
        }

        [HttpPost("sql")]
        public async Task<IActionResult> AddSqlUser([FromBody] SqlUser user)
        {
            await _userService.AddSqlUserAsync(user);
            return Ok();
        }

        [HttpGet("mongo")]
        public async Task<IActionResult> GetMongoDocuments()
        {
            var documents = await _userService.GetMongoDocumentsAsync();
            return Ok(documents);
        }

        [HttpPost("mongo")]
        public async Task<IActionResult> AddMongoDocument([FromBody] MongoDocument document)
        {
            await _userService.AddMongoDocumentAsync(document);
            return Ok();
        }
    }
}
