using System;
using System.Collections.Generic;

namespace PostApi
{
    public class PostException : Exception
    {
        public static readonly Dictionary<string, string> Exceptions = new()
        {
            {PostExceptionType.TitleIsRequired, "title is a required field"},
            {
                PostExceptionType.TitleIsInvalid,
                $"title must have minimum {Post.TitleMinLength.ToString()} " +
                $"and maximum {Post.TitleMaxLength.ToString()} characters"
            },

            {PostExceptionType.ContentIsRequired, "content is a required field"},
            {
                PostExceptionType.ContentIsInvalid,
                $"content must have maximum {Post.ContentMaxLength.ToString()} characters"
            },

            {PostExceptionType.PostAlreadyExists, "Post already exists"},
            {PostExceptionType.PostDoesNotExist, "Post does not exist"},


            {PostExceptionType.PostTypeIsRequired, "postType is a required field"},

            {PostExceptionType.PostLocationIsRequired, "location is a required field"},

            {PostExceptionType.UserIdIsRequired, "userId is a required field"},

            {
                PostExceptionType.SearchPostRequestInvalid,
                $"from must be greater or equal than {SearchPostRequest.FromMinValue}" +
                $" and size must be less or equal than {SearchPostRequest.SizeMaxValue}"
            }
        };

        public PostException(string type) : base(string.Format(Exceptions[type]))
        {
        }
    }
}