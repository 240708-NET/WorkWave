using Models;
using Repository;

namespace Services;

public class UserService
{

    private UserRepository repository;

    public UserService(UserRepository repository)
    {
        this.repository = repository;
    }

    public List<User> GetAll()
    {
        return repository.List();
    }

    public void DeleteById(int id)
    {
        User user = repository.GetById(id);
        repository.Delete(user);
    }

    public User Save(User user)
    {
        return repository.Save(user);
    }

    public User Update(int id, User user)
    {
        return repository.Update(id, user);
    }

    public User GetById(int id)
    {
        return repository.GetById(id);
    }

}
