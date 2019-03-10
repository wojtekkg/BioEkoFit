import React, { Component } from 'react';
import { InputGroup, FormControl } from 'react-bootstrap';

class AddProduct extends Component { 
    constructor(props) {
        super(props);
        this.onChange = this.onChange.bind(this);
    }

    onChange(event){
        const { value } = event.target;
        this.props.applyProductName(value);
    }

    render() {
        return (
        <div>
        <InputGroup className="mb-3">
            <FormControl
                placeholder="Nazwa produktu"
                aria-label="Nazwa produktu"
                aria-describedby="basic-addon1"
                onChange={this.onChange}
            />
        </InputGroup>
        </div> 
    )};
};

export default AddProduct;