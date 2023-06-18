namespace minhaapi.Infrastructure.Interfaces
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetByParameter(object whereConditions);
        IEnumerable<TEntity> GetListByParameter(object whereConditions);
        TEntity GetById(long id);
        Task<TEntity> GetByIdAsync(long id);
        int? Insert(TEntity entity);
        Task<int?> InsertAsync(TEntity entity);
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        int Delete(long id);
        Task<int> DeleteAsync(long id);

    }
}