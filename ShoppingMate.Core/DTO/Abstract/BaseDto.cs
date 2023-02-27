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


        [Display(Name = "Created At")]
        public DateTime CreateDate { get; set; }


        [MaxLength(500)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
