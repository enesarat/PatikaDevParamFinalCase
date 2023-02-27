using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingMate.Core.DTO.Abstract
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
