using _1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.Interface.Business
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll(
            Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = null, 
            int? skip = null, 
            int? take = null);

        List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = null, 
            int? skip = null, 
            int? take = null);
        
        TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        
        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        
        TEntity GetById(object id);      
        int GetCount(Expression<Func<TEntity, bool>> filter = null);      
        bool GetExists(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
    }
}
