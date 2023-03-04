using FluentValidation;
using ShoppingMate.Core.DTO.Concrete.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Validator.ShoppingList
{
    public class ShoppingListDtoValidator : AbstractValidator<ShoppingListDto>
    {
        public ShoppingListDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(" {PropertyName} must have any value ").NotEmpty().WithMessage(" {PropertyName} is required ");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
            RuleFor(x => x.TotalCost).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
        }
    }
}
