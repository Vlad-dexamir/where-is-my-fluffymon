import { WimfLocation } from './WimfLocation';

export interface UserInfo {
  readonly personId: string;
  readonly firstName: string;
  readonly email: string;
  readonly location: WimfLocation;
  readonly lastName?: string;
  readonly phoneNumber?: string;
  readonly profilePicture?: string;
}

export const PersonConstraints = {
  passwordMin: 8,
  passwordMax: 32,
};
