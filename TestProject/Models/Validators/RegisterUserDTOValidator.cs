using FluentValidation;
using TestProject.Entities;

namespace TestProject.Models.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDTOValidator(GroceryDbContext dbcontext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var EmailInUse = dbcontext.Users.Any(u => u.Email == value);
                if (EmailInUse)
                {
                    context.AddFailure("Email", "That Email is taken");
                }
            });
        }
    }
}
