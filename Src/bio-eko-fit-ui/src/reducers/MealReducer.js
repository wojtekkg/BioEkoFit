import { MEALS_ADD } from "../constants/actionTypes";

const INITIAL_STATE = []

const applyAddMeals = (state, action) => 
    action.meals;

function mealReducer(state = INITIAL_STATE, action) {
    switch(action.type){
        case MEALS_ADD: {
            return applyAddMeals(state, action);
        }
        default: return state;
    }
}

export default mealReducer;