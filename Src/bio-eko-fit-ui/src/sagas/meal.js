import { call, put } from 'redux-saga/effects';
import { doAddMeals } from '../actions/meals';
import { fetchMeals, addMeal, removeMeal } from '../api/meal';

function* handleFetchMeals() {
    const result = yield call(fetchMeals);
    yield put(doAddMeals(result.data));
}

function* handleAddMeal(action) {    const { meal } = action;
    yield call(addMeal, meal);
    yield handleFetchMeals();
}

function* handleRemoveMeal(action) {
    const { id } = action;
    yield call(removeMeal, id);
    yield handleFetchMeals();
}

export {
    handleFetchMeals,
    handleAddMeal,
    handleRemoveMeal,
};