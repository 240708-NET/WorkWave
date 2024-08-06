using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
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
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById( int id )
        {
            try
            {
                User user = this.service.GetById(id);
                return user != null ? Ok(user) : NotFound("User not found!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPut]
        public ActionResult<User> Update(int id, User user)
        {
            try
            {
                if(id != user.ID){
                    return BadRequest("User ID mismatch.");
                }

                User userFound = this.service.GetById(id);

                if (userFound == null){
                    return NotFound($"User with Id = {id} not found");
                }
                
                return this.service.Update(id, user);
                //return Update Ok("User updated!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        
        }

        [HttpPost]
        public ActionResult<User> Insert( [FromBody] User user )
        {
            try
            {
                User userCreated = this.service.Save(user);

                return CreatedAtAction(nameof(GetById), new { id = userCreated.ID }, userCreated);
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete( int id )
        {
            try
            {
                User userFound = this.service.GetById(id);

                if (userFound == null){
                    return NotFound($"User with Id = {id} not found");
                }

                this.service.DeleteById( id );
                return Ok($"User with Id = {id} Deleted!");
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}