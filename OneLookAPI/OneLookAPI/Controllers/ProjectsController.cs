using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneLookAPI.Models;

namespace OneLookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        OneLookContext _dbContext;
        public ProjectsController(OneLookContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<List<Project>> GetUserProject(int id)
        {
            var projects = await _dbContext.Projects.Where(x => x.UserId == id).ToListAsync();

            return projects;         
        }
    }
}
