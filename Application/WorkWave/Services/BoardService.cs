using Models;
using Repository;

namespace Services;

public class BoardService
{

    private IRepository<Board> repository;

    private UserService userService;

    public BoardService(IRepository<Board> repository, UserService userService)
    {
        this.repository = repository;
        this.userService = userService;
    }

    public List<Board> GetAll()
    {
        return repository.List();
    }

    public void DeleteById(int id)
    {
        Board board = repository.GetById(id);
        repository.Delete(board);
    }

    public Board Save(Board board)
    {
        
        return repository.Save(board);
    }

    public Board Update(int id, Board board)
    {
        return repository.Update(id, board);
    }

    public Board GetById(int id)
    {
        return repository.GetById(id);
    }

}
