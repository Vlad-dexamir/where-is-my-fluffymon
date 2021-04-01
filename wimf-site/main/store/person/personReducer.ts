import {
    SetInitialStateAction,
    InitialStateActionType,
} from '../setInitialStateAction';

import {PersonActionType, GetPersonSuccessAction} from './personActions';

type ActionType = SetInitialStateAction | GetPersonSuccessAction;

export const initialState = {};

export const personReducer = (
    person: any = initialState,
    action: ActionType,
): any => {
    switch (action.type) {
        case InitialStateActionType.SET_INITIAL_STATE:
            return initialState;

        case PersonActionType.GET_PERSON_SUCCESS:
            return action.payload;

        default: return person;
    }
};