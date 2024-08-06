using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ILogger<Section> logger;

        private SectionService service;

        public SectionController(ILogger<Section> logger, SectionService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Section>> GetAll()
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
        public ActionResult<Section> GetById( int id )
        {
            try
            {
                Section section = this.service.GetById(id);
                return section != null ? Ok(section) : NotFound("Section not found!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Section> Update(int id, Section section)
        {
            try
            {
                if(id != section.ID){
                    return BadRequest("Section ID mismatch.");
                }

                Section sectionFound = this.service.GetById(id);

                if (sectionFound == null){
                    return NotFound($"Section with Id = {id} not found");
                }
                
                return this.service.Update(id, section);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        
        }

        [HttpPost]
        public ActionResult<Section> Insert( [FromBody] Section section )
        {
            try
            {
                Section sectionCreated = this.service.Save(section);

                return CreatedAtAction(nameof(GetById), new { id = sectionCreated.ID }, sectionCreated);
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
                Section sectionFound = this.service.GetById(id);

                if (sectionFound == null){
                    return NotFound($"Section with Id = {id} not found");
                }

                this.service.DeleteById( id );
                return Ok($"Section with Id = {id} Deleted!");
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}