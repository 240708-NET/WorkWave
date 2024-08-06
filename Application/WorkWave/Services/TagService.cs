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

    public Tag Save(Tag tag)
    {
        return repository.Save(tag);
    }

    public Tag Update(int id, Tag tag)
    {
        return repository.Update(id, tag);
    }

    public Tag GetById(int id)
    {
        return repository.GetById(id);
    }

}
