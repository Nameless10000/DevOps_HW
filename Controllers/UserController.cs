using DevOps_HW.DTOs;
using DevOps_HW.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevOps_HW.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController(AppDbContext dbContext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserAddDTO userAddDTO)
        {
            var newUser = new User
            {
                Name = userAddDTO.Name,
                Email = userAddDTO.Email,
            };

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await dbContext.Users.ToListAsync();
        }
    }
}
