import { call, put } from 'redux-saga/effects';
import { doAddProducts } from '../actions/products';
import { fetchProducts, addProduct, removeProduct } from '../api/product';

function* handleFetchProducts() {
    const result = yield call(fetchProducts);
    yield put(doAddProducts(result.products));
}

function* handleAddProduct(action) {
    const { product } = action;
    yield call(addProduct, product);
    yield handleFetchProducts();
}

function* handleRemoveProduct(action) {
    const { id } = action;
    yield call(removeProduct, id);
    yield handleFetchProducts();
}

export {
    handleFetchProducts,
    handleAddProduct,
    handleRemoveProduct,
};