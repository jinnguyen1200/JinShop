using _1.Core.Domain.Business;
using _2.Data;
using _3.Service.Implement.Business;
using _3.Service.Interface.Business;
using Api.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiModels = Api.Models;
using ServiceModels = _3.Service.Models;

namespace Api.Controllers
{
    [RoutePrefix("api/jinshop")]
    public class JinShopController : BaseApiController
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public JinShopController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("allcategories")]
        [HttpGet]
        public IHttpActionResult GetAllCategory(
             int pageIndex = 1, 
             int pageSize = 10)
        {
            long totalCount = 0;
            pageIndex = pageIndex > 0 ? pageIndex : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            var data = _categoryService.GetAllPaging(pageIndex, pageSize, ref totalCount);
            var pagingRes = new PagingResult<ApiModels.Category.CategoryModel>
            {
                Data = data.Select(x => new ApiModels.Category.CategoryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Url = x.Url
                }).ToList(),
                TotalRecord = totalCount,
                TotalPage = (int)Math.Ceiling((double)totalCount / pageSize)
        };
            return SuccessResult(data: pagingRes);
        }
        
        [Route("allproducts")]
        [HttpGet]
        public IHttpActionResult GetAllProduct(
            int pageIndex = 1, 
            int pageSize = 10)
        {
            var totalCount = 0;
            var allData = _productService.GetAll(pageIndex, pageSize, ref totalCount);
            var pagingRes = new PagingResult<ApiModels.Product.ProductModel>
            {
                Data = allData.Select(x => new ApiModels.Product.ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive,
                    CategoryID = x.CategoryID,
                    CategoryName = x.Category != null ? x.Category.Name : "",
                }).ToList(),
                TotalRecord = totalCount
            };
            return SuccessResult(data: pagingRes);
        }
          

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAllProductSQL(
            int pageIndex = 1,
            int pageSize = 10)
        {
            long totalCount = 0;
            var data = _productService.GetAllProducts(pageIndex,pageSize, ref totalCount);
            var pagingRes = new PagingResult<ApiModels.Product.ProductModel>
            {
                Data = data.Select(x => new ApiModels.Product.ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive,
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName
                }).ToList(),
                TotalRecord = totalCount
            };
            return SuccessResult(data: pagingRes);
        }

        [Route("getallbycategory/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllProductByCategory([FromUri] int id)
        {
            if (id <= 0)
            {
                return ErrorResult("Product Id does not exist");
            }
            var data = _productService.GetAllProductsByCategoryId(id);
            var result = data.Select(x => new ApiModels.Product.ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                IsActive = x.IsActive,
                CategoryID = x.CategoryID
            }).ToList();
            return SuccessResult(data: result);
        }

        [Route("getallbyids")]
        [HttpPost]
        public IHttpActionResult GetAllProductByIds([FromBody] List<int> ids)
        {
            if(ids == null)
            {
                return ErrorResult("Ids not set");
            }
            var data = _productService.GetAllProductsByIds(ids);
            var result = data.Select(x => new ApiModels.Product.ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                IsActive = x.IsActive,
                CategoryID = x.CategoryID
            }).ToList();
            return SuccessResult(result, "Create Successful");
        }

        [Route("insert")]
        [HttpPost]
        public IHttpActionResult InsertProduct([FromBody] ProductCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var items in ModelState)
                {
                    foreach (var item in items.Value.Errors)
                    {
                        errors.Add(item.ErrorMessage);
                    }
                }
                return ErrorResult(errors);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                CategoryID = model.CategoryId
            };

            _productService.Create(product);
            return SuccessResult(message:"Create Successful");
            
        }

        [Route("update/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateProduct([FromUri] int id,[FromBody] ProductUpdateModel model)
        {
            try
            {
                var product = _productService.GetById(id);
                if (product is null)
                {
                    return ErrorResult("Product Id does not exist");
                }
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                _productService.Update(product);
                return SuccessResult(message: "Update Successful");
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct([FromUri] int id)
        {
            try
            {
                var product = _productService.GetById(id);
                if (product is null)
                {
                    return ErrorResult("Product Id does not exist");
                }
                _productService.Delete(id);
                return SuccessResult(message: "Delete Successfull");
            }
            catch (Exception ex)
            {
                return ErrorResult(ex.Message);
            }
        }
    }
}
