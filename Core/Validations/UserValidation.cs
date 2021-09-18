using Core.DTOs;
using FluentValidation;

namespace Core.Validations
{
    public class UserValidation:AbstractValidator<TodoDto>
    {
        public UserValidation()
        {
            RuleFor(x => x.Title)
                .MaximumLength(30)
                .NotEmpty();
            RuleFor(x => x.Description)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}