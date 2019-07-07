import { combineReducers } from 'redux';
import productsReducer from './ProductReducer';
import mealsReducer from './MealReducer';

const rootReducer = combineReducers({
  productsState: productsReducer,
  mealsState: mealsReducer
});

export default rootReducer;