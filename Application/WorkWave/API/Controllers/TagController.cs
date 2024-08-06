using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<Tag> logger;

        private TagService service;

        public TagController(ILogger<Tag> logger, TagService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Tag>> GetAll()
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
        public ActionResult<Tag> GetById( int id )
        {
            try
            {
                Tag tag = this.service.GetById(id);
                return tag != null ? Ok(tag) : NotFound("Tag not found!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Tag> Update(int id, Tag tag)
        {
            try
            {
                if(id != tag.ID){
                    return BadRequest("Tag ID mismatch.");
                }

                Tag tagFound = this.service.GetById(id);

                if (tagFound == null){
                    return NotFound($"Tag with Id = {id} not found");
                }
                
                return this.service.Update(id, tag);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        
        }

        [HttpPost]
        public ActionResult<Tag> Insert( [FromBody] Tag tag )
        {
             try
            {
                Tag tagCreated = this.service.Save(tag);

                return CreatedAtAction(nameof(GetById), new { id = tagCreated.ID }, tagCreated);
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
                Tag tagFound = this.service.GetById(id);

                if (tagFound == null){
                    return NotFound($"Tag with Id = {id} not found");
                }

                this.service.DeleteById( id );
                return Ok($"Tag with Id = {id} Deleted!");
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}