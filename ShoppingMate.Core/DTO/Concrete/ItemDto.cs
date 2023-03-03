using ShoppingMate.Core.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.DTO.Concrete
{
    public class ItemDto : BaseDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsBought { get; set; } = false;
    }
}
