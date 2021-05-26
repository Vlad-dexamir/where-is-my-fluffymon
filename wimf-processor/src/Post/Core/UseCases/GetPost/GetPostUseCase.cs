﻿using System;
using System.Threading.Tasks;

namespace PostApi
{
    public static class GetPostUseCase
    {
        public static readonly Func<GetPostDeps, string, Task<PostDto>> Execute =
            async (getPostDeps, postId) =>
            {
                var postRepository = getPostDeps.PostRepository;

                var foundPost = await postRepository.GetPost(postId);

                if (foundPost == null)
                {
                    throw new PostException(PostExceptionType.PostDoesNotExist);
                }

                return new PostDto
                {
                    PostId = foundPost.PostId,
                    Title = foundPost.Title,
                    Content = foundPost.Content,
                    UserId = foundPost.UserId,
                    UserInfo = foundPost.UserInfo,
                    Location = foundPost.Location,
                    Attachements = foundPost.Attachements,
                    CreatedAt = foundPost.CreatedAt,
                    UpdatedAt = foundPost.UpdatedAt
                };
            };
    }
}