using FluentValidation;
using ShoppingMate.Core.DTO.Concrete.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Validator.Item
{
    public class CreateItemDtoValidator : AbstractValidator<ItemCreateDto>
    {
        public CreateItemDtoValidator()
        {
            RuleFor(x => x.ProductId).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
            RuleFor(x => x.Quantity).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
        }
    }
}
