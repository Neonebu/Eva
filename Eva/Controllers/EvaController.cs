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


        public EvaController(ILogger<EvaController> logger,EvaDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [HttpGet(Name = "AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPost (Name = "GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _dbContext.users.ToListAsync();
            return Ok(users);
        }
    }
}
