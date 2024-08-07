using Models;
using Repository;

namespace Services;

public class CardService
{

    private IRepository<Card> repository;

    public CardService(IRepository<Card> repository)
    {
        this.repository = repository;
    }

    public List<Card> GetAll()
    {
        return repository.List();
    }

    public void DeleteById(int id)
    {
        Card card = repository.GetById(id);
        repository.Delete(card);
    }

    public Card Save(Card card)
    {
        return repository.Save(card);
    }

    public Card Update(int id, Card card)
    {
        return repository.Update(id, card);
    }

    public Card GetById(int id)
    {
        return repository.GetById(id);
    }

}
