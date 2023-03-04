using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete.Item
{
    public class ItemUpdateDto
    {
        public int Quantity { get; set; }
        public bool IsBought { get; set; } = false;
    }
}
