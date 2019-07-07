import { takeEvery, all } from 'redux-saga/effects';
import { PRODUCTS_FETCH, PRODUCTS_ADD_NEW, PRODUCTS_REMOVE, MEALS_FETCH, MEALS_ADD_NEW, MEALS_REMOVE } from '../constants/actionTypes';
import { handleFetchProducts, handleAddProduct, handleRemoveProduct } from './product';
import { handleFetchMeals, handleAddMeal, handleRemoveMeal } from './meal';

function *watchAll() {
    yield all([
        takeEvery(PRODUCTS_FETCH, handleFetchProducts),
        takeEvery(PRODUCTS_ADD_NEW, handleAddProduct),
        takeEvery(PRODUCTS_REMOVE, handleRemoveProduct),
        takeEvery(MEALS_FETCH, handleFetchMeals),
        takeEvery(MEALS_ADD_NEW, handleAddMeal),
        takeEvery(MEALS_REMOVE, handleRemoveMeal)
        
    ]);
}

export default watchAll;