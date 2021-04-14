using FluentValidation;

namespace PostApi
{
    public class CreateCommentRequest
    {
#nullable disable
        public string Comment { get; set; }
    }

    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentRequestValidator()
        {
            RuleFor(request => request.Comment)
                .NotEmpty()
                .NotNull()
                .WithMessage(CommentException.Exceptions[CommentExceptionType.CommentIsRequired]);
            RuleFor(request => request.Comment)
                .MinimumLength(Comment.NameMinLength)
                .MaximumLength(Comment.NameMaxLength)
                .WithMessage(CommentException.Exceptions[CommentExceptionType.CommentIsInvalid]);            
        }
    }
}
