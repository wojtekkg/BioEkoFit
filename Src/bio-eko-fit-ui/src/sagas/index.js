import { takeEvery, all } from 'redux-saga/effects';
import { PRODUCTS_FETCH, PRODUCTS_ADD_NEW, PRODUCTS_REMOVE } from '../constants/actionTypes';
import { handleFetchProducts, handleAddProduct, handleRemoveProduct } from './product';

function *watchAll() {
    yield all([
        takeEvery(PRODUCTS_FETCH, handleFetchProducts),
        takeEvery(PRODUCTS_ADD_NEW, handleAddProduct),
        takeEvery(PRODUCTS_REMOVE, handleRemoveProduct)
    ]);
}

export default watchAll;