import { Attachment } from './Attachment';
import { WimfLocation } from '../WimfLocation';
import { PersonInfo } from '../PersonInfo';

export type PostType = 'Found' | 'Lost' | 'Spotted';

export interface Post {
  readonly postId: string;
  readonly postType: PostType;
  readonly title: string;
  readonly content: string;
  readonly location: WimfLocation;
  readonly personId: string;
  readonly createdAt: number;
  readonly personInfo?: PersonInfo;
  readonly attachments?: Attachment[];
  readonly updatedAt?: number;
}
