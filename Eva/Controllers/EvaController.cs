using Eva.Context;
using Eva.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eva.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EvaController : ControllerBase
    {
        private readonly ILogger<EvaController> _logger;
        private readonly EvaDbContext _dbContext;


        public EvaController(ILogger<EvaController> logger, EvaDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _dbContext.users.ToListAsync();
            return Ok(users);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            _dbContext.users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string email)
        {
           var user = await _dbContext.users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) {
                return BadRequest("Not Found");
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
