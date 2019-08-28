using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Models.Product
{
    public class ProductCreateModel
    {
        [Required]
        [MinLength(10,ErrorMessage = "Tren 10 ky tu")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="Danh muc la bat buoc.")]
        public int CategoryId { get; set; }
    }

    public class ProductUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}