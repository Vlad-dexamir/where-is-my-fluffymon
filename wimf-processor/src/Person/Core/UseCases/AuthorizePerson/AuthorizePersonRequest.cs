using FluentValidation;
using Utils;

namespace PersonApi
{
    public class AuthorizePersonRequest
    { 
#nullable disable
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthorizePersonRequestValidator : Validator<AuthorizePersonRequest>
    {
        public AuthorizePersonRequestValidator()
        {
            RuleFor(authorizePersonRequest => authorizePersonRequest.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonEmailIsRequired]);
            RuleFor(authorizePersonRequest => authorizePersonRequest.Email)
                .Matches(Person.PersonEmailPattern)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonEmailIsInvalid]);

            RuleFor(authorizePersonRequest => authorizePersonRequest.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonPasswordIsRequired]);
            RuleFor(authorizePersonRequest => authorizePersonRequest.Password)
                .MinimumLength(Person.PasswordMinLength)
                .MaximumLength(Person.PasswordMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonPasswordIsInvalid]);
        }
    }
}