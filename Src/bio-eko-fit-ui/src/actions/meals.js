import { MEALS_REMOVE, MEALS_ADD, MEALS_FETCH, MEALS_ADD_NEW_TO_UI } from '../constants/actionTypes';

const doRemoveMeal = id => ({
    type: MEALS_REMOVE,
    id,
});

const doAddMeals = meals => ({
    type: MEALS_ADD,
    meals
});

const doFetchMeals = query => ({
    type: MEALS_FETCH,
    query,
});

const doAddNewMeal = meal => ({
    type: MEALS_ADD_NEW_TO_UI,
    meal
});

export {
    doRemoveMeal,
    doAddMeals,
    doFetchMeals,
    doAddNewMeal,
};