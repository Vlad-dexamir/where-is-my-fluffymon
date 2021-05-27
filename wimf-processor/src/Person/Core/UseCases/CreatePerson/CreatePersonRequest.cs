using FluentValidation;
using Utils;

namespace PersonApi
{
    public class CreatePersonRequest
    {
#nullable disable
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Location Location { get; set; }
#nullable enable
        public string? PhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
    }

    public class CreatePersonRequestValidator : Validator<CreatePersonRequest>
    {
        public CreatePersonRequestValidator()
        {
            RuleFor(request => request.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonFirstNameIsRequired]);
            RuleFor(request => request.FirstName)
                .MinimumLength(Person.NameMinLength)
                .MaximumLength(Person.NameMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonFirstNameIsInvalid]);

            RuleFor(request => request.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonLastNameIsRequired]);
            RuleFor(request => request.LastName)
                .MinimumLength(Person.NameMinLength)
                .MaximumLength(Person.NameMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonLastNameIsInvalid]);

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

            RuleFor(request => request.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonLocationIsRequired]);
        }
    }
}
