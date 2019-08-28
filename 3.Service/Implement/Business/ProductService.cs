using _0.Common.Helper;
using _1.Core.Domain.Business;
using _2.Data;
using _3.Service.Interface.Business;
using _3.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _3.Service.Implement.Business
{
    public class ProductService : BaseService<Product>, IProductService
    {
        #region fields
        private readonly JinShopContext _context;
        private readonly DbSet<Product> _dbSet;
        #endregion

        #region ctor
        public ProductService(JinShopContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }
        #endregion

        #region public methods
        public int GetCountByActive()
        {
            return GetCount(x => x.IsActive);
        }

        public List<Product> GetAll(int pageIndex , int pageSize, ref int totalCount)
        {
            var query = _dbSet.Include(x => x.Category).Where(x => true);
            totalCount = query.Count();
            var res = query.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1 ) * pageSize).Take(pageSize).ToList();
            return res;
        }

        public void Create(Product product)
        {
            _dbSet.Add(product);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _dbSet.Remove(product);
            _context.SaveChanges();
        }

        public List<ProductModel> GetAllProducts(int pageIndex, int pageSize, ref long totalCount)
        {
            var sql = "EXEC [dbo].[GetAllIProductWithPaging] @p0, @p1";
            var result = _context.Database.SqlQuery<ProductModel>(sql, pageIndex, pageSize).ToList();
            var record = result.FirstOrDefault();
            totalCount = record.RowCounts.GetValueOrDefault();
            result.Remove(record);
            return result;
        }

        public List<ProductModel> GetAllProductsByCategoryId(int categoryId)
        {
            var sql = "EXEC [GetAllProductByCategoryId] @p0";
            var result = _context.Database.SqlQuery<ProductModel>(sql, categoryId).ToList();
            return result;
        }

        public List<ProductModel> GetAllProductsByIds(List<int> ids)
        {
            var sql = @"Select * from product
                        where id in (@p0)";
            var result = _context.Database.ExtendedSqlQuery<ProductModel>(sql, new SqlListParameter("@p0") { Value = ids }).ToList();
            return result;
        }


        // get all product by categoryId
        // get all product by product Ids: 1,3,5
        #endregion

        #region private methods
        #endregion
    }
}