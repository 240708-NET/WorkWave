
namespace Repository{

    public interface IRepository<T>{

        void save(T t);

        void update(T t);
        List<T> list();
        void deleteById(int id);

        T getById(int id);
        
    }
}