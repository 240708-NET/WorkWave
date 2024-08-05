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
                return context.Cards.ToList();
        }

        public void Save(Card card){
                context.Add(card);
                context.SaveChanges();
        }

        public void Update(Card card){

                Card cardToUpdate = context.Cards.Find(card.ID);

                if(card != null){
                    cardToUpdate.Title = card.Title;
                    cardToUpdate.Description = card.Description;
                    cardToUpdate.Section = context.Sections.Find(card.Section.ID);
                    context.SaveChanges();
                }
        }

        public Card GetById(int id){
                return context.Cards.Find(id);
        }
    }

}