using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<Card> logger;

        private CardService service;

        public CardController(ILogger<Card> logger, CardService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public List<Card> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public Card GetById( int id )
        {
            return this.service.GetById(id);
        }

        [HttpPut]
        public bool Update(Card card)
        {
            try
            {
                this.service.Update(card);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        
        }

        [HttpPost]
        public Card Insert( [FromBody] Card card )
        {
            try
            {
                this.service.Save(card);
                var cards = this.service.GetAll();

                return cards.OrderByDescending(u => u.ID).FirstOrDefault();
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