using FluentValidation;
using ShoppingMate.Core.DTO.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Validator.Product
{
    public class CreateProductDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(" {PropertyName} must have any value ").NotEmpty().WithMessage(" {PropertyName} is required ");
            RuleFor(x => x.UnitType).NotNull().WithMessage(" {PropertyName} must have any value ").NotEmpty().WithMessage(" {PropertyName} is required ");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage(" {PropertyName} must be greater than 0 ");
        }
    }
}
