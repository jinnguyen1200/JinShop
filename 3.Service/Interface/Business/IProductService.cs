using _1.Core.Domain.Business;
using _3.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.Interface.Business
{
    public interface IProductService
    {
        void Create(Product product);
        void Update(Product product);
        Product GetById(int id);
        void Delete(int id);
        List<Product> GetAll(int pageIndex, int pageSize, ref int totalCount);
        List<ProductModel> GetAllProducts(int pageIndex, int pageSize, ref long totalCount);
        List<ProductModel> GetAllProductsByCategoryId(int categoryId);
        List<ProductModel> GetAllProductsByIds(List<int> ids);
    }
}
