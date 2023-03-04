using FluentValidation;
using ShoppingMate.Core.DTO.Concrete.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Validator.Item
{
    public class UpdateItemValidator : AbstractValidator<ItemUpdateDto>
    {
        public UpdateItemValidator()
        {
            RuleFor(x => x.Quantity).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
        }
    }
}
