using FluentValidation;

namespace CommentApi
{
    public class CreateCommentRequest
    {
#nullable disable
        public string Text { get; set; }
        public string PostId { get; set; }
        public string ParentId { get; set; }
        public string UserId { get; set; }
#nullable enable
        public UserInfo? UserInfo { get; set; }
        public long? UpdatedAt { get; set; }

    }

    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentRequestValidator()
        {
            RuleFor(request => request.Text)
                .NotEmpty()
                .NotNull()
                .WithMessage(CommentException.Exceptions[CommentExceptionType.TextIsRequired]);
            RuleFor(request => request.Text)
                .MinimumLength(Comment.MinLength)
                .MaximumLength(Comment.MaxLength)
                .WithMessage(CommentException.Exceptions[CommentExceptionType.TextIsInvalid]);            
        }
    }
}
