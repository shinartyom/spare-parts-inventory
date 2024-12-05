namespace WAD_00019330.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int it);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
