using Models;
using Repository;

namespace WorkWave.Tests
{

    public class MockBoardRepo : IRepository<Board>
    {

        private readonly List<Board> _boards;

        public MockBoardRepo()
        {
            _boards = new List<Board>
            {
                new Board {ID = 1, Name = "Board 1", Description = "This is the first board.", Users = new List<User>()},
                new Board {ID = 2, Name = "Board 2", Description = "This is the second board.", Users = new List<User>()}
            };
        }

        public void Delete(Board board)
        {
            _boards.Remove(board);
        }

        public List<Board> List()
        {
            return _boards;
        }

        public void Save(Board board)
        {
            _boards.Add(board);
        }

        public void Update(Board board)
        {
            var boardToUpdate = _boards.FirstOrDefault(b => b.ID == board.ID);
            if (boardToUpdate != null)
            {
                boardToUpdate.Name = board.Name;
                boardToUpdate.Description = board.Description;
                boardToUpdate.Users = board.Users;
            }
        }

        public Board GetById(int id)
        {
            return _boards.FirstOrDefault(b => b.ID == id);
        }
    }

}