using ShoppingMate.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Model.Concrete
{
    public class ShoppingList : BaseModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Item> Items { get; set; }
        public bool IsCompleted { get; set; } = false;
        public double TotalCost { get; set; }
        public DateTime? CompleteTime { get; set; }
    }
}
