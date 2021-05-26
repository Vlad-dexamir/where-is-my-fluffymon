using FluentValidation;
using Utils;

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
            RuleFor(request => request.Updates.Password.Action)
                .NotEqual(UpdateActionType.Delete);
            RuleFor(request => request.Updates.LastName.Action)
                .NotEqual(UpdateActionType.Delete);
            RuleFor(request => request.Updates.Location.Action)
                .NotEqual(UpdateActionType.Delete);
        }
    }
}