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

        public Section Save(Section section){
                context.Add(section);
                context.SaveChanges();
            return section;
        }

        public Section Update(int id, Section section){

                Section sectionToUpdate = context.Sections.Find(section.ID);

                if(section != null){
                    sectionToUpdate.Name = section.Name;
                    sectionToUpdate.Board = context.Boards.Find(section.Board.ID);
                    context.SaveChanges();
                    return context.Sections.Find(section.ID);
                }

            return null;
        }

        public Section GetById(int id){
                return context.Sections.Find(id);
        }
    }

}