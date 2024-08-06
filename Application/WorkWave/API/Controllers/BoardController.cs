using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<Board> logger;

        private BoardService service;

        public BoardController(ILogger<Board> logger, BoardService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Board>> GetAll()
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
        public ActionResult<Board> GetById( int id )
        {
            try
            {
                Board board = this.service.GetById(id);
                return board != null ? Ok(board) : NotFound("Board not found!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Board> Update(int id, Board board)
        {
            try
            {
                if(id != board.ID){
                    return BadRequest("Board ID mismatch.");
                }

                Board boardFound = this.service.GetById(id);

                if (boardFound == null){
                    return NotFound($"Board with Id = {id} not found");
                }
                
                return this.service.Update(id, board);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        
        }

        [HttpPost]
        public ActionResult<Board> Insert( [FromBody] Board board )
        {
            try
            {
                Board boardCreated = this.service.Save(board);

                return CreatedAtAction(nameof(GetById), new { id = boardCreated.ID }, boardCreated);
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
                Board boardFound = this.service.GetById(id);

                if (boardFound == null){
                    return NotFound($"Board with Id = {id} not found");
                }

                this.service.DeleteById( id );
                return Ok($"Board with Id = {id} Deleted!");
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

    }
}