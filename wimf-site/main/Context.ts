import { NextRouter } from 'next/router';

import { ApiService } from './domain/ApiService';

interface ContextDependencies {
    apiService: ApiService;
    routerService: NextRouter;
}

export class Context {
    static apiService: ApiService;
    static routerService: NextRouter;
    static BASE_PATH: string = '/where-is-my-fluffymon';

    static initialize(dependencies: ContextDependencies) {
        Context.apiService = dependencies.apiService;
        Context.routerService = dependencies.routerService;
    }
}