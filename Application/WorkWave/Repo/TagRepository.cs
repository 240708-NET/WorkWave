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

        public Tag Save(Tag tag)
        {
            context.Add(tag);
            context.SaveChanges();
            return tag;
        }

        public Tag Update(int id, Tag tag){

                Tag tagToUpdate = context.Tags.Find(tag.ID);

                if(tag != null){
                    tagToUpdate.Description = tag.Description;
                    tagToUpdate.Color = tag.Color;
                    context.SaveChanges();
                    return context.Tags.Find(tag.ID);
                }
                return null;
        }

        public Tag GetById(int id){
                return context.Tags.Find(id);
        }
    }

}