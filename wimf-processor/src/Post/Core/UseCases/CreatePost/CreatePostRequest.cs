using System.Collections.Generic;
using FluentValidation;

namespace PostApi
{
    public class CreatePostRequest
    {
#nullable disable
        public string PostType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserLocation Location { get; set; }
        public string UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public IEnumerable<string> Attachements { get; set; }
       
#nullable enable
        public long? UpdatedAt { get; set; }
    }

    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(request => request.PostType)
                .NotEmpty()
                .NotNull()
                .WithMessage(PostException.Exceptions[PostExceptionType.PostTypeIsRequired]);
            
            RuleFor(request => request.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage(PostException.Exceptions[PostExceptionType.TitleIsRequired]);
            RuleFor(request => request.Title)
                .MinimumLength(Post.TitleMinLength)
                .MaximumLength(Post.TitleMaxLength)
                .WithMessage(PostException.Exceptions[PostExceptionType.TitleIsInvalid]);

            RuleFor(request => request.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage(PostException.Exceptions[PostExceptionType.ContentIsRequired]);
            RuleFor(request => request.Content)
                .MaximumLength(Post.ContentMaxLength)
                .WithMessage(PostException.Exceptions[PostExceptionType.ContentIsInvalid]);

            RuleFor(request => request.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage(PostException.Exceptions[PostExceptionType.PostLocationIsRequired]);

            RuleFor(request => request.UserInfo)
                .NotEmpty()
                .NotNull()
                .WithMessage(PostException.Exceptions[PostExceptionType.UserInfoIsRequired]);
            
            RuleFor(request => request.Attachements)
                .NotEmpty()
                .NotNull()
                .WithMessage(PostException.Exceptions[PostExceptionType.AttachmentsIsRequired]);

           
        }
    }
}