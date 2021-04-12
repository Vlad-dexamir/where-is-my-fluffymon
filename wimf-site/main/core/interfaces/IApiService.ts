import { Post } from '../domain/Post/Post';

export interface IApiService {
  getPost(postId: string): Promise<Post>;
}
