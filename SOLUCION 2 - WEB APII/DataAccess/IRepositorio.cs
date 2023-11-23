namespace DataAccess
{
    public interface IRepositorio<T>
    {
        T Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();

    }
}