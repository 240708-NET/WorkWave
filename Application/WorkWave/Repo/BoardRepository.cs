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
                return context.Boards.ToList();
        }

        public void Save(Board board){
                context.Add(board);
                context.SaveChanges();
        }

        public void Update(Board board){

                Board boardToUpdate = context.Boards.Find(board.ID);

                if(board != null){
                    boardToUpdate.Name = board.Name;
                    boardToUpdate.Description = board.Description;
                    context.SaveChanges();
                }
        }

        public Board GetById(int id){
                return context.Boards.Find(id);
        }
    }

}