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
        public List<Section> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public Section GetById( int id )
        {
            return this.service.GetById(id);
        }

        [HttpPut]
        public bool Update(Section section)
        {
            try
            {
                this.service.Update(section);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        
        }

        [HttpPost]
        public Section Insert( [FromBody] Section section )
        {
            try
            {
                this.service.Save(section);
                var sections = this.service.GetAll();

                return sections.OrderByDescending(s => s.ID).FirstOrDefault();
            }
            catch
            {
                return null;
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