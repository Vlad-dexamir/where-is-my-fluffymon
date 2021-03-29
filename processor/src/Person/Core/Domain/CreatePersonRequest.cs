using FluentValidation;

namespace PersonApi
{
    public class CreatePersonRequest
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; set; }

        public PersonLocation Location { get; }

        public string? PhoneNumber => null;

        public string? ProfilePicture => null;
    }

    public class CreatePersonRequestValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonRequestValidator()
        {
            RuleFor(request => request.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonFirstNameIsRequired]);
            RuleFor(request => request.FirstName)
                .MinimumLength(Person.PersonConstraints["NAME_MIN"])
                .MaximumLength(Person.PersonConstraints["NAME_MAX"])
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonFirstNameIsInvalid]);

            RuleFor(request => request.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonLastNameIsRequired]);
            RuleFor(request => request.LastName)
                .MinimumLength(Person.PersonConstraints["NAME_MIN"])
                .MaximumLength(Person.PersonConstraints["NAME_MAX"])
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonLastNameIsInvalid]);

            RuleFor(request => request.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonEmailIsRequired]);
            RuleFor(request => request.Email)
                .Matches(Person.PersonEmailPattern)
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonEmailIsInvalid]);

            RuleFor(request => request.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonPasswordIsRequired]);
            RuleFor(request => request.Password)
                .MinimumLength(Person.PersonConstraints["PASSWORD_MIN"])
                .MaximumLength(Person.PersonConstraints["PASSWORD_MAX"])
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonPasswordIsInvalid]);

            RuleFor(request => request.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonLocationIsRequired]);

            RuleFor(request => request.PhoneNumber.Length)
                .Equal(Person.PersonConstraints["PHONE_NUMBER_LENGTH"])
                .WithMessage(PersonException.PersonExceptions[PersonExceptionType.PersonPhoneNumberIsInvalid]);
        }
    }
}