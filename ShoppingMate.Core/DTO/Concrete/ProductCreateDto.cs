using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string UnitType { get; set; }
        public int CategoryId { get; set; }
    }
}
