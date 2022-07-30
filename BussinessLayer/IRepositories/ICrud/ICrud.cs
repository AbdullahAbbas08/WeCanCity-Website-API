using System.Linq.Expressions;

namespace BusinessLayer.IRepositories.ICrud
{ 
    public interface ICrud<T> where T : class
    {
        IQueryable<T> GetAll(); 
        IQueryable<T> Get(Expression<Func<T, bool>> match);
        Task<T> Add(T Entity);
        Task<List<T>> AddRange(List<T> Entity);
        T Update(T Entity);
        Task<bool> Delete(Expression<Func<T, bool>> match); 
    }
}