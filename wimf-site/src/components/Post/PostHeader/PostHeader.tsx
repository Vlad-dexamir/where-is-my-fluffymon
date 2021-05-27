import React from 'react';

import { PostComponentsProps } from '../../../core/domain/Post/PostComponenetsProps';

import {
  PostHeaderWrapper,
  PostHeaderMetadataWrapper,
  PostHeaderMetadataElement,
  PostHeaderTitle,
} from './PostHeaderStyles';

export const PostHeader: React.FC<PostComponentsProps> = ({ post }) => (
  <PostHeaderWrapper>
    <PostHeaderTitle>{post.title}</PostHeaderTitle>
    <PostHeaderMetadataWrapper>
      <PostHeaderMetadataElement>{post.postType}</PostHeaderMetadataElement>
      {post.userInfo && (
        <PostHeaderMetadataElement>
          {`${post.userInfo.firstName} ${post.userInfo.lastName || ''}`}
        </PostHeaderMetadataElement>
      )}
      <PostHeaderMetadataElement>{post.createdAt}</PostHeaderMetadataElement>
    </PostHeaderMetadataWrapper>
  </PostHeaderWrapper>
);
