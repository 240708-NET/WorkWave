using Models;

namespace Repository
{

    public class SectionRepository : IRepository<Section>
    {
        DataContext context;
        public SectionRepository(DataContext context){
            this.context = context;
        }

        public void Delete(Section section){
            context.Sections.Remove(section);
            context.SaveChanges();
        }

        public List<Section> List(){
                return context.Sections.ToList();
        }

        public void Save(Section section){
                context.Add(section);
                context.SaveChanges();
        }

        public void Update(Section section){

                Section sectionToUpdate = context.Sections.Find(section.ID);

                if(section != null){
                    sectionToUpdate.Name = section.Name;
                    sectionToUpdate.Board = context.Boards.Find(section.Board.ID);
                    context.SaveChanges();
                }
        }

        public Section GetById(int id){
                return context.Sections.Find(id);
        }
    }

}