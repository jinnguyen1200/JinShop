using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Core.Domain.Business
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
