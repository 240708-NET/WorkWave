using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<User> logger;

        private UserService service;

        public UserController(ILogger<User> logger, UserService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public User GetById( int id )
        {
            return this.service.GetById(id);
        }

        [HttpPut]
        public bool Update(User user)
        {
            try
            {
                this.service.Update(user);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        
        }

        [HttpPost]
        public User Insert( [FromBody] User user )
        {
            try
            {
                this.service.Save(user);
                var tasks = this.service.GetAll();

                return tasks.OrderByDescending(u => u.ID).FirstOrDefault();
            }
            catch
            {
                return new User();
            }
        }

        [HttpDelete("{id}")]
        public bool Delete( int id )
        {
            try
            {
                this.service.DeleteById( id );
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}