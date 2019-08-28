using _1.Core.Domain.Business;
using _3.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.Interface.Business
{
    public interface ICategoryService : IBaseService<Category>
    {
        List<CategoryModel> GetAllPaging(int pageIndex, int pageSize, ref long totalCount);
    }
}
