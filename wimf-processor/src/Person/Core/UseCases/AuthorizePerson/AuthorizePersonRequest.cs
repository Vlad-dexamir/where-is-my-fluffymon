using FluentValidation;

namespace PersonApi
{
    public class AuthorizePersonRequest
    { 
#nullable disable
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthorizePersonRequestValidator : AbstractValidator<AuthorizePersonRequest>
    {
        

        public AuthorizePersonRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonEmailIsRequired]);
            RuleFor(request => request.Email)
                .Matches(Person.PersonEmailPattern)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonEmailIsInvalid]);

            RuleFor(request => request.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonPasswordIsRequired]);
            RuleFor(request => request.Password)
                .MinimumLength(Person.PasswordMinLength)
                .MaximumLength(Person.PasswordMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonPasswordIsInvalid]);
        }
    }
}