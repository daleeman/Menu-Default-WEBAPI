namespace Menu_Default_WEBAPI.Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll();
        Task<T?> GetById(Guid Id);
    }
}
