using Models;

namespace Repository
{

    public class TagRepository : IRepository<Tag>
    {
        DataContext context;
        public TagRepository(DataContext context){
            this.context = context;
        }

        public void Delete(Tag tag){
            context.Tags.Remove(tag);
            context.SaveChanges();
        }

        public List<Tag> List(){
                return context.Tags.ToList();
        }

        public void Save(Tag tag){
                context.Add(tag);
                context.SaveChanges();
        }

        public void Update(Tag tag){

                Tag tagToUpdate = context.Tags.Find(tag.ID);

                if(tag != null){
                    tagToUpdate.Description = tag.Description;
                    tagToUpdate.Color = tag.Color;
                    context.SaveChanges();
                }
        }

        public Tag GetById(int id){
                return context.Tags.Find(id);
        }
    }

}