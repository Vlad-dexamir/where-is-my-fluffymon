import { IApiService } from '../core/interfaces/IApiService';
import { AxiosService } from './AxiosService';
import {Context} from "../Context";
import {SearchPostResponse} from "../core/domain/Post/SearchPostResponse";
import {SearchPostRequest} from "../core/domain/Post/SearchPostRequest";
import {CreatePostPayload, Post} from "../core/domain/Post/Post";
import {AuthorizeUserPayload, CreateUserPayload} from "../core/domain/User";

export class HttpApiService implements IApiService {
  private postsAxiosInstance: AxiosService;
  private personAxiosInstance: AxiosService;

  constructor() {
    const headers =  {
        'Ocp-Apim-Subscription-Key': 'dddc233cda2041c2a6256ac9337b7be2',
        'Ocp-Apim-Trace': true
      };

    this.postsAxiosInstance = new AxiosService({
      headers,
      baseURL : Context.POSTS_API_URL,
    });

    this.personAxiosInstance = new AxiosService({
      headers,
      baseURL: Context.PERSON_API_URL,
    })
  }

  getPost(postId: string): Promise<Post> {
    return this.postsAxiosInstance.get<string, Post>(`/post/${postId}`);
  }

  searchPost(searchRequest: SearchPostRequest): Promise<SearchPostResponse> {
    const queryString = SearchPostRequest.queryString(searchRequest);

    return this.postsAxiosInstance.get<string, SearchPostResponse>(`/search-post?${queryString}`);
  }

  createPost(payload: CreatePostPayload): Promise<Post> {
    return this.postsAxiosInstance.post<CreatePostPayload, Post>('/post', payload);
  }

  createUser(payload: CreateUserPayload): Promise<string> {
    return this.personAxiosInstance.post<CreateUserPayload, string>('/create-person', payload);
  }

  authorizeUser(payload: AuthorizeUserPayload): Promise<string> {
    return this.personAxiosInstance.post<AuthorizeUserPayload, string>('/person', payload);
  }
}
