using System.Data;
using Dapper;
using minhaapi.Infrastructure.Interfaces;
using MySql.Data.MySqlClient;

namespace minhaapi.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly string? ConnectionString;

        public RepositoryBase(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("defaultConnection");
        }

        public IDbConnection GetOpenConnection()
        {
            IDbConnection connection;
            connection = new MySqlConnection(ConnectionString);
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);

            connection.Open();
            return connection;
        }

        public IDbTransaction GetTransaction()
        {
            IDbTransaction transaction = GetOpenConnection().BeginTransaction();
            return transaction;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using var db = GetOpenConnection();
                return db.GetList<TEntity>();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                using var db = GetOpenConnection();
                return db.GetListAsync<TEntity>();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public TEntity GetById(long id)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.Get<TEntity>(id);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<TEntity> GetByIdAsync(long id)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.GetAsync<TEntity>(id);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public TEntity GetByParameter(object whereConditions)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.GetList<TEntity>(whereConditions).FirstOrDefault();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TEntity> GetListByParameter(object whereConditions)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.GetList<TEntity>(whereConditions);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int Delete(long id)
        {
            try
            {
                using var db = GetOpenConnection();
                var entity = GetById(id);
                if(entity is null) throw new Exception(Common.Messages.Database.RegisterNotFound);

                return db.Delete(entity);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<int> DeleteAsync(long id)
        {
            try
            {
                using var db = GetOpenConnection();
                var entity = GetById(id);
                if(entity is null) throw new Exception(Common.Messages.Database.RegisterNotFound);

                return db.DeleteAsync(entity);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        public int? Insert(TEntity entity)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.Insert<TEntity>(entity);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<int?> InsertAsync(TEntity entity)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.InsertAsync<TEntity>(entity);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int Update(TEntity entity)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.Update<TEntity>(entity);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                using var db = GetOpenConnection();
                return db.UpdateAsync<TEntity>(entity);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}