import { PRODUCTS_REMOVE, PRODUCTS_ADD, PRODUCTS_FETCH } from '../constants/actionTypes';

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
})

export {
    doRemoveProduct,
    doAddProducts,
    doFetchProducts
};