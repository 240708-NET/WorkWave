using Models;
using Repository;

namespace Services;

public class BoardService
{

    private BoardRepository repository;

    public BoardService(BoardRepository repository)
    {
        this.repository = repository;
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

    public void Save(Board board)
    {
        repository.Save(board);
    }

    public void Update(Board board)
    {
        repository.Update(board);
    }

    public Board GetById(int id)
    {
        return repository.GetById(id);
    }

}
