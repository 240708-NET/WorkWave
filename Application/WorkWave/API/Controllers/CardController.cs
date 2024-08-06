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
        public ActionResult<List<Card>> GetAll()
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
        public ActionResult<Card> GetById( int id )
        {
            try
            {
                Card card = this.service.GetById(id);
                return card != null ? Ok(card) : NotFound("Card not found!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Card> Update(int id, Card card)
        {
            try
            {
                if(id != card.ID){
                    return BadRequest("Card ID mismatch.");
                }

                Card cardFound = this.service.GetById(id);

                if (cardFound == null){
                    return NotFound($"Card with Id = {id} not found");
                }
                
                return this.service.Update(id, card);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        
        }

        [HttpPost]
        public ActionResult<Card> Insert( [FromBody] Card card )
        {
            try
            {
                Card cardCreated = this.service.Save(card);

                return CreatedAtAction(nameof(GetById), new { id = cardCreated.ID }, cardCreated);
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
                Card cardFound = this.service.GetById(id);

                if (cardFound == null){
                    return NotFound($"Card with Id = {id} not found");
                }

                this.service.DeleteById( id );
                return Ok($"Card with Id = {id} Deleted!");
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}