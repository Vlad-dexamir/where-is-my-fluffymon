using FluentValidation;

namespace PersonApi
{
    public class CreatePersonRequest
    {
        
#nullable disable
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PersonLocation Location { get; set; }

#nullable enable

        public string? PhoneNumber { get; set; }

        public string? ProfilePicture { get; set; }
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
        }
    }
}
