using Models;
using Repository;

namespace Services;

public class UserService
{

    private UserRepository repository;

    public List<User> GetAll()
    {
        return repository.List();
    }

    public void DeleteById(int id)
    {
        User user = repository.GetById(id);
        repository.Delete(user);
    }

    public void Save(User user)
    {
        repository.Save(user);
    }

    public void Update(User user)
    {
        repository.Update(user);
    }

    public User GetById(int id)
    {
        repository.GetById(id);
    }

}
