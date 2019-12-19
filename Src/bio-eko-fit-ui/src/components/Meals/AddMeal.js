import React, { Component } from 'react';
import { InputGroup, FormControl, Card, Button, Accordion } from 'react-bootstrap';
import Steps from './Steps';
import ProductsAccordion from './ProductsAccordion';

class AddMeal extends Component { 
    constructor(props) {
        super(props);
        this.onChange = this.onChange.bind(this);
    }

    onChange(event){
        const { value } = event.target;
        this.props.applyMealName(value);
    }

    render() {
        return (
        <div>
                <Accordion className="col-md-12" defaultActiveKey="0">
                    <Card>
                        <Card.Header>
                            <Accordion.Toggle as={Card.Header} variant="link" eventKey="0">
                                Ogólne
                            </Accordion.Toggle>
                        </Card.Header>
                        <Accordion.Collapse eventKey="0">
                            <Card.Body>
                            <InputGroup className="mb-3">
                                <FormControl
                                    placeholder="Nazwa posiłku"
                                    aria-label="Nazwa posiłku"
                                    aria-describedby="basic-addon1"
                                    onChange={this.onChange}
                                />
                            </InputGroup>
                            </Card.Body>
                        </Accordion.Collapse>
                    </Card>
                    <Card>
                        <Card.Header>
                            <Accordion.Toggle as={Card.Header} variant="link" eventKey="1">
                                Produkty
                            </Accordion.Toggle>
                        </Card.Header>
                        <Accordion.Collapse eventKey="1">
                            <Card.Body>
                                <ProductsAccordion products={[ { name: "banan", weight: "50g" }, { name: "czosnek", weight: "100g" } ]}>
                                    
                                </ProductsAccordion>
                            </Card.Body>
                        </Accordion.Collapse>
                    </Card>
                    <Card>
                        <Card.Header>
                            <Accordion.Toggle as={Card.Header} variant="link" eventKey="2">
                                Kroki
                            </Accordion.Toggle>
                        </Card.Header>
                        <Accordion.Collapse eventKey="2">
                            <Card.Body>
                                <Steps steps={[ {description: "Pierw obierz", order: 2}, { description: "Później pokrój", order: 1}]}>
                                    
                                </Steps>
                            </Card.Body>
                        </Accordion.Collapse>
                    </Card>
                </Accordion>
        </div> 
    )};
};

export default AddMeal;