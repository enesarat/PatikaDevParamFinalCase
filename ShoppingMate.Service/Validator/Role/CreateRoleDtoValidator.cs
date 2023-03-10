using FluentValidation;
using ShoppingMate.Core.DTO.Concrete.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMate.Service.Validator.Role
{
    public class CreateRoleDtoValidator : AbstractValidator<RoleCreateDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(" {PropertyName} must have any value ").NotEmpty().WithMessage(" {PropertyName} is required ");
        }
    }
}
