using Models;
using Repository;

namespace Services;

public class SectionService
{

    private SectionRepository repository;

    public SectionService(SectionRepository repository)
    {
        this.repository = repository;
    }

    public List<Section> GetAll()
    {
        return repository.List();
    }

    public void DeleteById(int id)
    {
        Section section = repository.GetById(id);
        repository.Delete(section);
    }

    public void Save(Section section)
    {
        repository.Save(section);
    }

    public void Update(Section section)
    {
        repository.Update(section);
    }

    public Section GetById(int id)
    {
        return repository.GetById(id);
    }

}
