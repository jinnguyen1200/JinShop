using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Core.Domain.Business
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
