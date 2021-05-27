import {Post} from "./Post";

export interface SearchPostResponse {
    total: number;
    posts: Post[];
}
