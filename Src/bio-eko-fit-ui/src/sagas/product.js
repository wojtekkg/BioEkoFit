import { call, put } from 'redux-saga/effects';
import { doAddProducts } from '../actions/products';
import { fetchProducts } from '../api/product';

function* handleFetchProducts(action) {
    const { query } = action;
    const result = yield call(fetchProducts, query);
    yield put(doAddProducts(result.products));
}

export {
    handleFetchProducts,
};