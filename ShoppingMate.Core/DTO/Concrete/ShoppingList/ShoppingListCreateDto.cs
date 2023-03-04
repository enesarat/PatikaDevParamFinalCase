using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete.ShoppingList
{
    public class ShoppingListCreateDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
