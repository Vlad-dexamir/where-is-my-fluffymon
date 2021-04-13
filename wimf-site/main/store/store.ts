import { applyMiddleware, combineReducers, createStore, Reducer } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';

import { AppState } from './AppState';
import { postReducer } from './post/postReducer';

const rootReducer: Reducer<AppState> = combineReducers<AppState>({
  post: postReducer,
});

export const initializeStore = (initialState?: AppState) =>
  createStore(
    rootReducer,
    initialState,
    process.env.NODE_ENV === 'development'
      ? composeWithDevTools(applyMiddleware(thunk))
      : applyMiddleware(thunk),
  );
