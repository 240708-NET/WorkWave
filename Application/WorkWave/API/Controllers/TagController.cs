using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
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
        public List<Tag> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public Tag GetById( int id )
        {
            return this.service.GetById(id);
        }

        [HttpPut]
        public bool Update(Tag tag)
        {
            try
            {
                this.service.Update(tag);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        
        }

        [HttpPost]
        public Tag Insert( [FromBody] Tag tag )
        {
            try
            {
                this.service.Save(tag);
                var tags = this.service.GetAll();

                return tags.OrderByDescending(t => t.ID).FirstOrDefault();
            }
            catch
            {
                return new Tag();
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