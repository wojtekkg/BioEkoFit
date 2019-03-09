import { PRODUCTS_ADD, PRODUCTS_REMOVE } from "../constants/actionTypes";

const INITIAL_STATE = []

const applyAddProducts = (state, action) => 
    action.products;

const removeProduct = (state, action) => {
    var removeIndex = state.map(item => item.id).indexOf(action.id);
    ~removeIndex && state.splice(removeIndex, 1);
    return [...state];
}

function productReducer(state = INITIAL_STATE, action) {
    console.log(action);
    switch(action.type){
        case PRODUCTS_ADD: {
            return applyAddProducts(state, action);
        }
        case PRODUCTS_REMOVE: {
            return removeProduct(state, action);
        }
        default: return state;
    }
}

export default productReducer;