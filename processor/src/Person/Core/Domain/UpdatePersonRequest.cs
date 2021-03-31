using FluentValidation;

namespace PersonApi
{
    public class UpdatePersonRequest
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
        public string? PersonId { get; set; }
    }

    public class UpdatePersonRequestValidator : AbstractValidator<CreatePersonRequest>
    {
        public UpdatePersonRequestValidator(personId)
        {            
            RuleFor(request => request.FirstName)
                .MinimumLength(Person.NameMinLength)
                .MaximumLength(Person.NameMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonFirstNameIsInvalid]);

            RuleFor(request => request.LastName)
                .MinimumLength(Person.NameMinLength)
                .MaximumLength(Person.NameMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonLastNameIsInvalid]);

            RuleFor(request => request.Email)
                .Matches(Person.PersonEmailPattern)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonEmailIsInvalid]);

            RuleFor(request => request.Password)
                .MinimumLength(Person.PasswordMinLength)
                .MaximumLength(Person.PasswordMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonPasswordIsInvalid]);

            RuleFor(request => request.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonLocationIsRequired]);

            RuleFor(request => request.phoneNumber)
                .MinimumLength(Person.PhoneNumberMinLength)
                .MaximumLength(Person.PhoneNumberMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PhoneNumberError]);

            //Cum verific daca personId este echivalent
        }
    }
}
