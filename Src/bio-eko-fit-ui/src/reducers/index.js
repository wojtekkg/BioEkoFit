import { combineReducers } from 'redux';
import productsReducer from './ProductReducer';

const rootReducer = combineReducers({
  productsState: productsReducer,
});

export default rootReducer;