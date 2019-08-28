using _1.Core;
using _2.Data;
using _3.Service.Interface.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.Implement.Business
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly JinShopContext _context;
        public BaseService(JinShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
           return _dbSet.ToList();
        }

        public List<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.Count();
        }

        public bool GetExists(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();
            bool flag = false;
            if (filter != null)
            {
                flag = query.Any(filter);
            }
            return flag;

            //return filter != null ? _dbSet.Any(filter) : false;

        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            TEntity entity = null ;
            var query = _dbSet.AsQueryable();
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                 entity = query.FirstOrDefault(filter);
            }
            return entity;
        }
    
        public TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
