using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneLookAPI.Models;

namespace OneLookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        OneLookContext _dbContext;
        public UsersController(OneLookContext dbContext)
        {
            _dbContext = dbContext;   
        }

        [HttpGet]   
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();

            if(users==null)
            {
                throw new Exception("error");
            }
            else
            {
                return users;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u=>u.UserId==id);
            if (user == null)
            {
                throw new Exception("error");
            }
            else
            {
                return user;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(Request request)
        {
            User newUser = new User();
            newUser.UserName = request.name;
            newUser.Password = request.password;
            newUser.Email = request.email;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, Request request)
        {
            await _dbContext.Users.FirstAsync(u => u.UserId == id);
            var user = new User();

            user.UserName = request.name;
            user.Password = request.password;
            user.Email = request.email;

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _dbContext.Users.FirstAsync(u => u.UserId == id);

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
