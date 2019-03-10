import React, { Component } from 'react';
import './Products.css';
import { connect } from 'react-redux';
import { getProducts } from '../../selectors/products';
import { doFetchProducts, doAddNewProduct } from '../../actions/products';
import ProductsHeader from './ProductsHeader';
import {Button} from 'react-bootstrap';

import Product from './Product';
import CommonModal from '../CommonModal';
import AddProduct from './AddProduct';

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

const applyShowModal = showModal => () => ({
    showModal
});

class Products extends Component {
    constructor(props) {
        super(props);

        this.state = {
            product:{
                name: '',
            },
            showModal: false,
        };
        this.onSubmit = this.onSubmit.bind(this);
    }

    componentDidMount(prevProps) {
        this.props.onFetchProducts();
    }

    onSubmit(event) {
        this.setState(applyShowModal(true));  
        event.preventDefault();
      }

    applyProductName(name){
        this.setState({
            product: {
                name
            }
        });
    }

    handleAddProduct(){
        this.props.onAddProduct(this.state.product);
        this.setState(applyShowModal(false));  
    }

    state ={
        product: {
            name: '',
        },
        showModal: false,
    }
    render() {
        return <div className="products">
            <div style={{marginLeft: 20}} className="row">
            <form onSubmit={this.onSubmit}>
                <Button type="submit">Dodaj produkt</Button>
                <CommonModal 
                    show={this.state.showModal} 
                    onHide={() => this.setState(applyShowModal(false))}
                    onHideLabel="Anuluj"
                    onAccept={this.handleAddProduct.bind(this)}
                    onAcceptLabel="Dodaj"
                    header="Dodawanie nowego produktu"   
                >
                <AddProduct applyProductName={this.applyProductName.bind(this)}/>
                </CommonModal>
            </form>
            </div>
            <hr></hr>
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
    onAddProduct: product => dispatch(doAddNewProduct(product)),
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Products);
