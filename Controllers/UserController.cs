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
        public async Task<JsonResult> AddUser([FromBody] UserAddDTO userAddDTO)
        {
            Console.WriteLine("Add user entered");

            var newUser = new User
            {
                Name = userAddDTO.Name,
                Email = userAddDTO.Email,
            };

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            Console.WriteLine($"Add user finished {newUser}");

            return new (newUser);
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var users = await dbContext.Users.ToListAsync();

            Console.WriteLine($"GetAll entered {string.Join(", ", users)}");

            return new (users);
        }

        [HttpGet]
        public async Task<IActionResult> MigrateDb()
        {
            Console.WriteLine("MigrateDb entered");

            await dbContext.Database.MigrateAsync();

            return new JsonResult("migration completed");
        }
    }
}
