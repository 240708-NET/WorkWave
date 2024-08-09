using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{

    public class CardRepository : IRepository<Card>
    {
        DataContext context;
        public CardRepository(DataContext context){
            this.context = context;
        }

        public void Delete(Card card){
            context.Cards.Remove(card);
            context.SaveChanges();
        }

        public List<Card> List(){
                return context.Cards.Include(card => card.Section).ToList();
        }

        public Card Save(Card card){
                card.Section = context.Sections.Find(card.Section.ID);
                context.Add(card);
                context.SaveChanges();
            return card;
        }

        public Card Update(int id, Card card){

                Card cardToUpdate = context.Cards.Find(id);

                if(card != null){
                    cardToUpdate.Title = card.Title;
                    cardToUpdate.Description = card.Description;
                    cardToUpdate.Section = context.Sections.Find(card.Section.ID);
                    context.SaveChanges();
                    return context.Cards.Find(id);
                }

            return null;
        }

        public Card GetById(int id){
                return context.Cards.Find(id);
        }
    }

}