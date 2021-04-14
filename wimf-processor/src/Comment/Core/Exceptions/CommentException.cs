using System;
using System.Collections.Generic;

namespace CommentApi
{
    public class CommentException : Exception
    {
        public static readonly Dictionary<string, string> Exceptions = new()
        {
            { CommentExceptionType.TextIsRequired, "Comment is a required field" },
            {
                CommentExceptionType.TextIsInvalid,
                $"Comment must have minimum {Comment.MinLength.ToString()} " +
                $"and maximum {Comment.MaxLength.ToString()} characters"
            },
            { CommentExceptionType.CommentsDoNotExist, "Comments do not exist" },
            { CommentExceptionType.UserIdIsRequired, "userId is a required field" },
            { CommentExceptionType.UserInfoIsRequired, "userInfo is a required field" },
            { CommentExceptionType.CreatedAtIsRequired, "createdAt is a required field" }
        };

        public CommentException(string type) : base(string.Format(Exceptions[type]))
        {
        }
    }
}