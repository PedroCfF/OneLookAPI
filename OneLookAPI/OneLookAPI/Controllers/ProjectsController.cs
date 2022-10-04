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
        public async Task<ActionResult<List<Project>>> GetProjects(int id)
        {
            var projects = await _dbContext.Projects.ToListAsync();

            var userProjects = projects.Where(p => p.UserId == id).ToList();

            if (userProjects == null)
            {
                throw new Exception("error");
            }
            else
            {
                return userProjects;
            }
        }
    }
}
