using System;
using System.Collections.Generic;

namespace PostApi
{
    public class CommentException : Exception
    {
        public static readonly Dictionary<string, string> Exceptions = new()
        {
            { CommentExceptionType.CommentIsRequired, "Comment is a required field" },
            {
                CommentExceptionType.CommentIsInvalid,
                $"Comment must have minimum {Comment.CommentMinLength.ToString()} " +
                $"and maximum {Comment.CommentMaxLength.ToString()} characters"
            }
        };

        public CommentException(string type) : base(string.Format(Exceptions[type]))
        {
        }
    }
}