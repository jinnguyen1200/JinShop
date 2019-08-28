using _1.Core.Domain.Business;
using _2.Data;
using _3.Service.Interface.Business;
using _3.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.Implement.Business
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        #region fields
        private readonly JinShopContext _context;
        private readonly DbSet<Category> _dbset;
        #endregion

        #region ctor
        public CategoryService(JinShopContext context) : base(context)
        {
            _context = context;
            _dbset = _context.Set<Category>();
        }
        #endregion

        #region public methods
        public List<CategoryModel> GetAllPaging(int pageIndex, int pageSize, ref long totalCount)
        {
            var sql = "EXEC [dbo].[GetAllCategoryWithPaging] @p0, @p1";
            var result = _context.Database.SqlQuery<CategoryModel>(sql, pageIndex, pageSize).ToList();
            var record = result.FirstOrDefault();
            totalCount = record.RowCounts.GetValueOrDefault();
            result.Remove(record);
            return result;
        }
        #endregion

    }
}
