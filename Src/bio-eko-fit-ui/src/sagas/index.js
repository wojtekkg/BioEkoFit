import { takeEvery, all } from 'redux-saga/effects';
import { PRODUCTS_FETCH } from '../constants/actionTypes';
import { handleFetchProducts } from './product';

function *watchAll() {
    yield all([
        takeEvery(PRODUCTS_FETCH, handleFetchProducts),
    ])
}

export default watchAll;