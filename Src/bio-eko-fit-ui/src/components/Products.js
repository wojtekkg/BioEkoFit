import React, { Component } from 'react';
import './Products.css';
import { connect } from 'react-redux';
import { getProducts } from '../selectors/products';
import { doFetchProducts } from '../actions/products';


import Product from './Product';

const COLUMNS = {
    id: {
        label: 'Id',
        width: '30%'
    },
    name: {
        label: 'Nazwa',
        width: '50%'
    },
    actions: {
        label: 'Akcje',
        width: '20%'
    }
}

const ProductsHeader = ({ columns }) =>
    <div className="products-header">
        {Object.keys(columns).map(key =>
            <span
            key={key}
            style={{ width: columns[key].width }}
            >
                {columns[key].label}
            </span>
        )}
    </div>

class Products extends Component {
    componentDidMount(prevProps) {
        this.props.onFetchProducts();
    }

    render() {
        return <div className="products">
            <ProductsHeader columns={COLUMNS}/>
            {(this.props.products || []).map(product => 
                <Product 
                    key={product.id}
                    product={product}
                    columns={COLUMNS}
                />
            )}
        </div>
    } 
}

const mapStateToProps = state => ({
    products: getProducts(state),
});

const mapDispatchToProps = (dispatch) => ({
    onFetchProducts: () => dispatch(doFetchProducts()),
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Products);
