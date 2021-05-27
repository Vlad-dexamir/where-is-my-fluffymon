import { Attachment } from './Attachment';
import { WimfLocation } from '../WimfLocation';
import { UserInfo } from '../UserInfo';

export type PostType = 'Found' | 'Lost' | 'Spotted';

export interface Post {
  readonly postId: string;
  readonly postType: PostType;
  readonly title: string;
  readonly content: string;
  readonly location: WimfLocation;
  readonly personId: string;
  readonly createdAt: number;
  readonly userInfo?: UserInfo;
  readonly attachments?: Attachment[];
  readonly reward?: number;
  readonly updatedAt?: number;
}

export interface CreatePostPayload {
  readonly postType: PostType;
  readonly title: string;
  readonly content: string;
  readonly location: WimfLocation;
  readonly userId: string;
  readonly userInfo?: UserInfo;
  readonly attachements?: string[];
  readonly reward?: number;
}
