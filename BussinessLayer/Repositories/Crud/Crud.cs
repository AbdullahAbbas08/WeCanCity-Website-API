using BusinessLayer.IRepositories.ICrud;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Risk_Business_Layer.Repositories.Crud
{
    public class Crud<T> : ICrud<T> where T : class
    {
        #region Declare Variables
        private readonly Db_Context DbContext;
        #endregion

        #region Constructor
        public Crud(Db_Context DbContext)
        {
            this.DbContext = DbContext;
        }
        #endregion

        #region Add
        public virtual async Task<T> Add(T Entity)
        {
           await DbContext.AddAsync(Entity);
           return Entity;
        }

        public async Task<List<T>> AddRange(List<T> Entities)
        {
            await DbContext.AddRangeAsync(Entities);
            return Entities;
        }
        #endregion

        #region Delete
        public virtual async Task<bool> Delete(Expression<Func<T, bool>> match)
        {
            var Entity =  Get(match);


            if (Entity.Count() >0)
            {
                DbContext.Remove(Entity);
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion


        #region Get With Condition

        public IQueryable<T> Get(Expression<Func<T, bool>> match)
        {
           return DbContext.Set<T>().Where(match).AsQueryable();
        }
        #endregion

        #region GetAll
        public IQueryable<T> GetAll()
        {
            return  DbContext.Set<T>().AsQueryable();
        }
        #endregion

        #region Update
        public virtual T Update(T Entity)
        {
            var UpdatedEntity = DbContext.Update(Entity).Entity;
            return UpdatedEntity;
        }
        #endregion

    }
}
