using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{

    public class UserRepository : IRepository<User>
    {
        DataContext context;
        public UserRepository(string connectionstring){
            DbContextOptions<DataContext> options;
            options = new DbContextOptionsBuilder<DataContext>()
                            .UseSqlServer(connectionstring)
                            .Options;
            context = new DataContext(options);
        }

        public void Delete(User user){
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<User> List(){
                return context.Users.ToList();
        }

        public void Save(User user){
                context.Add(user);
                context.SaveChanges();
        }

        public void Update(User user){

                User userToUpdate = context.Users.Find(user.ID);

                if(user != null){
                    userToUpdate.FullName = user.FullName;
                    userToUpdate.Email = user.Email;
                    userToUpdate.Password = user.Password;
                    context.SaveChanges();
                }
        }

        public User GetById(int id){
                return context.Users.Find(id);
        }
    }

}