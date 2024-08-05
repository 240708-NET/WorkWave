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
        public List<Board> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public Board GetById( int id )
        {
            return this.service.GetById(id);
        }

        [HttpPut]
        public bool Update(Board board)
        {
            try
            {
                this.service.Update(board);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        
        }

        [HttpPost]
        public Board Insert( [FromBody] Board board )
        {
            try
            {
                this.service.Save(board);
                var boards = this.service.GetAll();

                return boards.OrderByDescending(u => u.ID).FirstOrDefault();
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