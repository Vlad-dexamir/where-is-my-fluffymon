using System;
using System.Collections.Generic;

namespace CommentApi
{
    public class CommentException : Exception
    {
        public static readonly Dictionary<string, string> Exceptions = new()
        {
            {CommentExceptionType.TextIsRequired, "text is a required field"},
            {
                CommentExceptionType.TextIsInvalid,
                $"text must have minimum {Comment.MinLength.ToString()} " +
                $"and maximum {Comment.MaxLength.ToString()} characters"
            },
            {CommentExceptionType.CommentsDoNotExist, "Comments do not exist"},
            {CommentExceptionType.UserIdIsRequired, "userId is a required field"},
            {CommentExceptionType.CreatedAtIsRequired, "createdAt is a required field"},
            {CommentExceptionType.PostIdIsRequired, "postId is a required field"}
        };

        public CommentException(string type) : base(string.Format(Exceptions[type]))
        {
        }
    }
}