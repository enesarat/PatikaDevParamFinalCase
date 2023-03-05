using ShoppingMate.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Model.Concrete
{
    public class ItemShoppingListJoint : BaseModel
    {
        public int ItemId { get; set; }
        public int ShoppingListId { get; set; }
        public Item Item { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
