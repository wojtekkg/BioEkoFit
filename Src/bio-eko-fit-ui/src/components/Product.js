import React from 'react';
import { connect } from 'react-redux';
import { doRemoveProduct } from '../actions/products';
import './Product.css';


const Product = ({ product, columns, removeProduct }) => {
    const {
        id,
        name,
    } = product;

    return (
        <div className="product">
            <span style={{ width: columns.id.width}}>{id}</span>
            <span style={{ width: columns.name.width}}>{name}</span>
            <span style={{ width: columns.actions.width}}><button onClick={() => removeProduct(id)}>Usuń</button></span>
        </div>
    );
}

const mapDispatchToProps = dispatch => ({
    removeProduct: id => dispatch(doRemoveProduct(id)),
});

export default connect(
    null, 
    mapDispatchToProps
)(Product);