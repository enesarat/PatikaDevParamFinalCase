using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete.Item
{
    public class ItemCreateDto
    {
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }

        public int Quantity { get; set; }
    }
}
