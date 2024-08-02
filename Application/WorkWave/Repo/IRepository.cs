
namespace Repository{

    public interface IRepository<T>{

        void Save(T t);

        void Update(T t);

        List<T> List();

        void Delete(T t);

        T GetById(int Id);
        
    }
}