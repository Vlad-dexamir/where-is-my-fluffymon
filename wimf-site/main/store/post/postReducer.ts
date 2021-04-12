import {
  InitialStateActionType,
  SetInitialStateAction,
} from '../setInitialStateAction';
import { GetPostSuccessAction, PostActionType } from './postActions';
import { Post } from '../../core/domain/Post/Post';

type ActionType = SetInitialStateAction | GetPostSuccessAction;

export const initialState: Post = {
  postId: '',
  postType: 'Found',
  title: '',
  content: '',
  location: {
    lat: 0,
    lng: 0,
  },
  personId: '',
  createdAt: 0,
  attachments: [],
  updatedAt: 0,
};

export const postReducer = (
  post: Post = initialState,
  action: ActionType,
): Post => {
  switch (action.type) {
    case InitialStateActionType.SET_INITIAL_STATE:
      return initialState;

    case PostActionType.GET_POST_SUCCESS:
      return action.payload.post;

    default:
      return post;
  }
};
