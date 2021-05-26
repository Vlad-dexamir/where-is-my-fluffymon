using System.Collections.Generic;
using FluentValidation;
using Utils;

namespace PostApi
{
    public class UpdatePostRequestUpdates
    {
#nullable enable

        public UpdateAction<string>? Title { get; set; }
        public UpdateAction<string>? Content { get; set; }
        public UpdateAction<IEnumerable<string>>? Attachements { get; set; }
    }

#nullable disable

    public class UpdatePostRequest
    {
        public UpdatePostRequestUpdates Updates { get; set; }
    }

    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(request => request.Updates).NotEmpty().NotNull();
            RuleFor(request => request.Updates.Title.Action)
                .NotEqual(UpdateActionType.Delete);
            RuleFor(request => request.Updates.Content.Action)
                .NotEqual(UpdateActionType.Delete);
        }
    }
}