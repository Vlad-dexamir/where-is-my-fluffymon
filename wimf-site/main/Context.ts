import { NextRouter } from 'next/router';
import { IApiService } from './core/interfaces/IApiService';

interface ContextDeps {
  apiService: IApiService;
  routerService: NextRouter;
}

export class Context {
  static apiService: IApiService;
  static routerService: NextRouter;
  static BASE_PATH: string = '/';

  static initialize(deps: ContextDeps) {
    Context.apiService = deps.apiService;
    Context.routerService = deps.routerService;
  }
}
