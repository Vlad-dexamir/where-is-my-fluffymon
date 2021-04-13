import { IApiService } from '../core/interfaces/IApiService';
import { Post } from '../core/domain/Post/Post';
import { AxiosService } from './AxiosService';
import { initialState } from '../store/post/postReducer';

export class HttpApiService implements IApiService {
  private axiosInstance: AxiosService;

  constructor() {
    this.axiosInstance = new AxiosService({});
  }

  getPost(postId: string): Promise<Post> {
    return Promise.resolve(initialState);
  }
}
