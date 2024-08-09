using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{

    public class UserRepository : IRepository<User>
    {
        DataContext context;
        public UserRepository(DataContext context){
            this.context = context;
        }

        public void Delete(User user){
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<User> List(){
                return context.Users.Include(user => user.Boards).ToList();
        }

        public User Save(User user){
                context.Add(user);
                context.SaveChanges();
            return user;
        }

        public User Update(int id, User user){

                User userToUpdate = context.Users.Find(id);

                if(user != null){
                    userToUpdate.FullName = user.FullName;
                    userToUpdate.Email = user.Email;
                    userToUpdate.Password = user.Password;
                    context.SaveChanges();
                    return context.Users.Find(id);
                }

            return null;
        }

        public User GetById(int id){
                return context.Users.Find(id);
        }

        public User GetByEmail(string email){
            return null;
        }
    }

}