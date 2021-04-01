using FluentValidation;

namespace PersonApi
{
    public class UpdatePersonRequestUpdates
    {
        public UpdateAction<string>? LastName { get; set; }
        public UpdateAction<string>? Password { get; set; }
        public UpdateAction<string>? PhoneNumber { get; set; }
        public UpdateAction<string>? ProfilePicture { get; set; }
        public UpdateAction<PersonLocation>? Location { get; set; }
    }

    public class UpdatePersonRequest
    {
#nullable disable
        public UpdatePersonRequestUpdates Updates { get; set; }
    }

    public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequest>
    {
        public UpdatePersonRequestValidator()
        {
            RuleFor(request => request.Updates).NotEmpty().NotNull();
            
            RuleFor(request => request.Updates.LastName.Action).Equal(UpdateActionType.Put);
            RuleFor(request=>request.Updates.LastName.Value)
                .NotNull()
                .NotEmpty()
                .MinimumLength(Person.NameMinLength)
                .MaximumLength(Person.NameMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonLastNameIsInvalid]);

            RuleFor(request => request.Updates.Password.Action).Equal(UpdateActionType.Put);
            RuleFor(request=>request.Updates.Password.Value)
                .NotNull()
                .NotEmpty()
                .MinimumLength(Person.PasswordMinLength)
                .MaximumLength(Person.PasswordMaxLength)
                .WithMessage(PersonException.Exceptions[PersonExceptionType.PersonPasswordIsInvalid]);

            RuleFor(request => request.Updates.Location.Action).Equal(UpdateActionType.Put);
            RuleFor(request => request.Updates.Location.Value).NotNull().NotEmpty();
        }
    }
}