using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Model.Abstract
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
