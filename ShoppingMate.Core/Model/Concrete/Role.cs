using ShoppingMate.Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Core.Model.Concrete
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
