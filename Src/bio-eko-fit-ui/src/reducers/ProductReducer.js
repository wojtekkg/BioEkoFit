import { PRODUCTS_ADD } from "../constants/actionTypes";

const INITIAL_STATE = []

const applyAddProducts = (state, action) => 
    action.products;

function productReducer(state = INITIAL_STATE, action) {
    switch(action.type){
        case PRODUCTS_ADD: {
            return applyAddProducts(state, action);
        }
        default: return state;
    }
}

export default productReducer;