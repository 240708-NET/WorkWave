using Models;
using Repository;

namespace Services;

public class TagService
{

    private TagRepository repository;

    public TagService(TagRepository repository)
    {
        this.repository = repository;
    }

    public List<Tag> GetAll()
    {
        return repository.List();
    }

    public void DeleteById(int id)
    {
        Tag tag = repository.GetById(id);
        repository.Delete(tag);
    }

    public void Save(Tag tag)
    {
        repository.Save(tag);
    }

    public void Update(Tag tag)
    {
        repository.Update(tag);
    }

    public Tag GetById(int id)
    {
        return repository.GetById(id);
    }

}
