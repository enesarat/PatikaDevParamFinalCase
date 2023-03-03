using ShoppingMate.Core.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete
{
    public class ShoppingListDto : BaseDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public double TotalCost { get; set; }
    }
}
