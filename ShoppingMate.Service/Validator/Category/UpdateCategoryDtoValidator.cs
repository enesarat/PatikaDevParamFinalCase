using FluentValidation;
using ShoppingMate.Core.DTO.Concrete.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Validator.Category
{
    public class UpdateCategoryDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(" {PropertyName} must have any value ").NotEmpty().WithMessage(" {PropertyName} is required ");
        }
    }
}
