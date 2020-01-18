import React, { Component } from 'react';
import { Button, Form, Col, Row } from 'react-bootstrap';
import { Typeahead } from 'react-bootstrap-typeahead';
import { Formik, Field } from 'formik';
import * as yup from 'yup';

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

const schema = yup.object({
    productName: yup.string().required("To pole jest wymagane"),
    productWeight: yup.string().required("To pole jest wymagane"),
  });

class ProductsAccordion extends Component {
    constructor(props){
        super(props);

        this.state = {
            products: [],
            key: 1,
        }
        this.handleAddProductToMeal = this.handleAddProductToMeal.bind(this);
    }

    handleAddProductToMeal(data){
        this.setState((prevState, props) => ({
            key: prevState.key + 1,
            products: prevState.products.concat({ key: prevState.key, "name": data.productName.name, "weight": data.productWeight })
        }))
    }

    render() {
        return <div>
            <Formik
                validationSchema={schema}
                onSubmit={this.handleAddProductToMeal}
                initialValues={{
                    productName: '',
                    productWeight: ''
                }}
                >
                {({
                    handleSubmit,
                    handleChange,
                    handleBlur,
                    values,
                    touched,
                    isValid,
                    errors,
                }) => (
                    <Form noValidate onSubmit={handleSubmit}>
                        <Field as={Row}>

                        <Form.Group as={Col} md="6" controlId="validationFormik05">
                            <Field 
                                name="productName" 
                                value={values.productName}
                                onBlur={handleBlur}
                                onChange={handleChange}
                                isInvalid={!!errors.productName}
                                >
                                {({field, form }) =>(
                                    <Typeahead
                                    id="hire-person-select"
                                    labelKey="name"
                                    isInvalid={!!errors.productName}
                                    onChange={productName => {
                                        if (productName){
                                            form.setFieldValue("productName", (productName.length === 0 ? [] : productName[0]));
                                        }
                                    }}
                                    options={[{ "name": "burak"}, { "name":"czosnek"}]}
                                    placeholder="Nazwa produktu"
                                    />
                                    )}
                            </Field>
                            <Form.Control name="productName" style={{display: "none"}} value={values.productName} onBlur={handleBlur} onChange={handleChange} isInvalid={!!errors.productName}></Form.Control>
                            <Form.Control.Feedback type="invalid">
                                {errors.productName}
                            </Form.Control.Feedback>
                        </Form.Group>
                        
                        <Form.Group as={Col} md="3" controlId="validationFormik06">
                        <Form.Control
                            type="text"
                            placeholder="waga (g)"
                            name="productWeight"
                            value={values.productWeight}
                            onChange={handleChange}
                            isInvalid={!!errors.productWeight}
                            />

                        <Form.Control.Feedback type="invalid">
                            {errors.productWeight}
                        </Form.Control.Feedback>
                        </Form.Group>
                        <Field as={Col} md="3">
                            <Button type="submit">Dodaj produkt</Button>
                        </Field>

                        </Field>
                    </Form>               
                )}
            </Formik>
            <table>
                <tbody>
                    {this.state.products.map(product =>
                        <tr key={product.key}>
                            <td style={{ width: COLUMNS.name.width }}>{product.name}</td>
                            <td style={{ width: COLUMNS.weight.width }}>{product.weight}</td>
                        </tr>
                    )}
                </tbody>
            </table>
             
        </div>
    }
} 

export default ProductsAccordion;