import { PRODUCTS_REMOVE, PRODUCTS_ADD, PRODUCTS_FETCH, PRODUCTS_ADD_NEW_TO_UI } from '../constants/actionTypes';

const doRemoveProduct = id => ({
    type: PRODUCTS_REMOVE,
    id,
});

const doAddProducts = products => ({
    type: PRODUCTS_ADD,
    products
});

const doFetchProducts = query => ({
    type: PRODUCTS_FETCH,
    query,
});

const doAddNewProduct = product => ({
    type: PRODUCTS_ADD_NEW_TO_UI,
    product
});

export {
    doRemoveProduct,
    doAddProducts,
    doFetchProducts,
    doAddNewProduct,
};