import {Action} from "redux";

export enum PersonActionType {
    GET_PERSON = 'GET_PERSON',
    GET_PERSON_SUCCESS = 'GET_PERSON_SUCCESS',
    GET_PERSON_ERROR = 'GET_PERSON_ERROR',
}

export interface GetPersonAction extends Action {
    type:  PersonActionType.GET_PERSON;
}

export interface GetPersonSuccessAction extends Action {
    type: PersonActionType.GET_PERSON_SUCCESS;
    payload: {} //TODO update with Person
}

export interface GetPersonErrorAction extends Action {
    type: PersonActionType.GET_PERSON_ERROR;
    payload: Error;
}

export const getPersonAction = (): GetPersonAction => ({
    type: PersonActionType.GET_PERSON,
});

export const getPersonSuccessAction = (): GetPersonSuccessAction => ({
    type: PersonActionType.GET_PERSON_SUCCESS,
    payload: {}
});

export const getPersonErrorAction = (error: Error): GetPersonErrorAction => ({
    type: PersonActionType.GET_PERSON_ERROR,
    payload: error,
})