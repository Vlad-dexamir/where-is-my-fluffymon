import queryString from 'query-string';
import {PostFilters} from "./PostFilters";

interface Payload {
    readonly from?: number;
    readonly size?: number;
    readonly postFilters?: PostFilters;
}

export class SearchPostRequest {
    static defaultFrom = 0;
    static defaultSize = 10;

    static create(request?: Payload) {
        return new SearchPostRequest(request || {});
    }

    static queryString(search: SearchPostRequest) {
        return queryString.stringify(
            {
                from: search.from,
                size: search.size,
                ...search.filters,
            },
            { skipNull: true },
        );
    }

    readonly from: number;
    readonly size: number;
    readonly filters?: PostFilters

    private constructor({ from, size, postFilters }: Payload) {
        this.from = from || SearchPostRequest.defaultFrom;
        this.size = size || SearchPostRequest.defaultSize;

        if (postFilters) {
            this.filters = postFilters;
        }
    }
}
