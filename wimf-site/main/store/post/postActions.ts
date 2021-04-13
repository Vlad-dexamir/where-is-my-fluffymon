import { Action } from 'redux';
import { Post } from '../../core/domain/Post/Post';

export enum PostActionType {
  GET_POST = 'GET_POST',
  GET_POST_SUCCESS = 'GET_POST_SUCCESS',
  GET_POST_ERROR = 'GET_POST_ERROR',
}

export interface GetPostAction extends Action {
  type: PostActionType.GET_POST;
}

export interface GetPostSuccessAction extends Action {
  type: PostActionType.GET_POST_SUCCESS;
  payload: {
    post: Post;
  };
}

export interface GetPostErrorAction extends Action {
  type: PostActionType.GET_POST_ERROR;
  payload: {
    error: Error;
  };
}

export const getPostAction = (): GetPostAction => ({
  type: PostActionType.GET_POST,
});

export const getPostSuccessAction = (post: Post): GetPostSuccessAction => ({
  type: PostActionType.GET_POST_SUCCESS,
  payload: {
    post,
  },
});

export const getPostErrorAction = (error: Error): GetPostErrorAction => ({
  type: PostActionType.GET_POST_ERROR,
  payload: {
    error,
  },
});
