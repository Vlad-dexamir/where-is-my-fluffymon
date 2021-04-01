import { applyMiddleware, combineReducers, createStore, Reducer } from 'redux';
import { AppState } from './AppState';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import {personReducer} from "./person/personReducer";

const rootReducer: Reducer<AppState> = combineReducers<AppState>({
    person: personReducer,
});

export const initializeStore = (initialState?: AppState) =>
    createStore(
        rootReducer,
        initialState,
        process.env.NODE_ENV === 'development'
            ? composeWithDevTools(applyMiddleware(thunk))
            : applyMiddleware(thunk),
    );