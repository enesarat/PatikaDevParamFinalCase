using ShoppingMate.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Model.Concrete
{
    public class Item : BaseModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
        public int Quantity { get; set; }
        public bool IsBought { get; set; } = false;
    }
}
