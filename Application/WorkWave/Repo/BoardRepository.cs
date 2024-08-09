using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{

    public class BoardRepository : IRepository<Board>
    {
        DataContext context;
        public BoardRepository(DataContext context){
            this.context = context;
        }

        public void Delete(Board board){
            context.Boards.Remove(board);
            context.SaveChanges();
        }

        public List<Board> List(){
                return context.Boards.Include(board => board.Users).ToList();
        }

        public Board Save(Board board){
                List<User> users = new List<User>();
                board.Users.ForEach(u => {
                    users.Add(context.Users.Find(u.ID));
                });
                board.Users = users;
                context.Add(board);
                context.SaveChanges();
            return board;
        }

        public Board Update(int id, Board board){

                Board boardToUpdate = context.Boards.Find(board.ID);

                if(board != null){
                    boardToUpdate.Name = board.Name;
                    boardToUpdate.Description = board.Description;
                    context.SaveChanges();
                    return context.Boards.Find(board.ID);
                }
                return null;
        }

        public Board GetById(int id){
                return context.Boards.Find(id);
        }
    }

}