import { WimfLocation } from './WimfLocation';

export interface PersonInfo {
  readonly personId: string;
  readonly firstName: string;
  readonly email: string;
  readonly location: WimfLocation;
  readonly lastName?: string;
  readonly phoneNumber?: string;
  readonly profilePicture?: string;
}
