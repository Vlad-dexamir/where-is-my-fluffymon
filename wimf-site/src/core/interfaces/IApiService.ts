import {CreatePostPayload, Post} from '../domain/Post/Post';
import {SearchPostRequest} from "../domain/Post/SearchPostRequest";
import {SearchPostResponse} from "../domain/Post/SearchPostResponse";
import {AuthorizeUserPayload, CreateUserPayload} from "../domain/User";

export interface IApiService {
  getPost(postId: string): Promise<Post>;

  searchPost(searchRequest: SearchPostRequest): Promise<SearchPostResponse>;

  createPost(payload: CreatePostPayload): Promise<Post>;

  createUser(payload: CreateUserPayload): Promise<string>;

  authorizeUser(payload: AuthorizeUserPayload): Promise<string>;
}
