using Models;
using Repository;

namespace Services;

public class CardService
{

    private CardRepository repository;

    public CardService(CardRepository repository)
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

    public void Save(Card card)
    {
        repository.Save(card);
    }

    public void Update(Card card)
    {
        repository.Update(card);
    }

    public Card GetById(int id)
    {
        return repository.GetById(id);
    }

}
