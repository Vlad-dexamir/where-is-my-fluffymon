import {PostType} from "./Post";
import {WimfLocation} from "../WimfLocation";

export interface PostFilters {
    postType?: PostType;
    userId?: string;
    query?: string;
    location?: WimfLocation;
}
