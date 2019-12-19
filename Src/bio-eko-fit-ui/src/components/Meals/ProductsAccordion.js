import React, { Component } from 'react';
import { InputGroup, FormControl, Button } from 'react-bootstrap';

const COLUMNS = {
    name: {
        label: 'Nazwa',
        width: '50%'
    },
    weight: {
        label: 'Waga',
        width: '50%'
    }
}

class ProductsAccordion extends Component {
    constructor(props){
        super(props);

        this.state = {
            products: this.props.products,
        }
    }

    render() {
        return <div>
            <InputGroup>
            <FormControl
                    placeholder="Nazwa produktu"
                    aria-label="Nazwa produktu"
                    aria-describedby="basic-addon1"
                    onChange={this.onChange}
                    style={{ width: "63%"}}
                />
            <FormControl
                    placeholder="Waga (g)"
                    aria-label="Waga (g)"
                    aria-describedby="basic-addon1"
                    onChange={this.onChange}
                    style={{width: "8%"}}
                />    
                <span style={{width: "4%"}}>g</span>
                <Button type="submit">Dodaj produkt</Button>
            </InputGroup>
            <table>
                {this.state.products.map(product =>
                    <tr>
                        <td style={{ width: COLUMNS.name.width }}>{product.name}</td>
                        <td style={{ width: COLUMNS.weight.width }}>{product.weight}</td>
                    </tr>
                )}
            </table>
             
        </div>
    }
} 

export default ProductsAccordion;