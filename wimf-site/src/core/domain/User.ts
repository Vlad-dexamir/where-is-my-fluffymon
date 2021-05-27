import {WimfLocation} from "./WimfLocation";

export interface CreateUserPayload {
    readonly firstName: string;
    readonly password: string;
    readonly email: string;
    readonly location: WimfLocation;
    readonly lastName?: string;
    readonly phoneNumber?: string;
    readonly profilePicture?: string;
}

export interface AuthorizeUserPayload {
    readonly email: string;
    readonly password: string;
}
