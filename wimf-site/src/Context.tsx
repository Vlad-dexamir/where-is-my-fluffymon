import { IApiService } from './core/interfaces/IApiService';
import {AlertService} from "./services/AlertService";

interface ContextDeps {
    apiService: IApiService;
    alertService: AlertService;
}

export class Context {
    static apiService: IApiService;
    static alertService: AlertService;
    static BASE_PATH: string = '/wimf';
    static POSTS_API_URL: string = 'https://wimf-posts-api.azure-api.net/wimf-post/v1';
    static PERSON_API_URL: string = 'https://wimf-person-api.azure-api.net/wimf-person/v1/';

    static initialize(deps: ContextDeps) {
        Context.apiService = deps.apiService;
        Context.alertService = deps.alertService;
    }

    static isUserAuthorized() {
        const userJwt = localStorage.getItem('jwtToken');

        return !!userJwt;
    }
}
