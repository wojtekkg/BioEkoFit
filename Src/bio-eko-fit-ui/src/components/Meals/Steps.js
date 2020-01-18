import React, { Component } from 'react';
import { Button, Form, Col, Row } from 'react-bootstrap';
import { Formik, Field } from 'formik';
import * as yup from 'yup';

const schema = yup.object({
    stepDescription: yup.string().required("To pole jest wymagane"),
  });

class Steps extends Component{
    constructor(props){
        super(props);

        this.state = {
            steps: [],
            key: 1,
        };
        this.handleAddStepToMeal = this.handleAddStepToMeal.bind(this);
    }
    
    handleAddStepToMeal(data){
        console.log(this.state.steps);
        this.setState((prevState, props) => ({
            key: prevState.key + 1,
            steps: prevState.steps.concat({ key: prevState.key, "description": data.stepDescription })
        }))
    }

    render() {
        return <div>
            <Formik
                validationSchema={schema}
                onSubmit={this.handleAddStepToMeal}
                initialValues={{
                    stepDescription: '',
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
                            <Form.Group as={Col} md="9" controlId="validationFormik06">
                            <Form.Control
                                type="text"
                                placeholder="Opis kroku"
                                name="stepDescription"
                                value={values.stepDescription}
                                onChange={handleChange}
                                isInvalid={!!errors.stepDescription}
                                />

                            <Form.Control.Feedback type="invalid">
                                {errors.stepDescription}
                            </Form.Control.Feedback>
                            </Form.Group>
                            <Field as={Col} md="3">
                                <Button type="submit">Dodaj krok</Button>
                            </Field>
                        </Field>
                    </Form>               
                )}
            </Formik>
            <br />
            <table>
                <tbody>
                    {this.state.steps.sort((a,b) => a.key - b.key).map(step => 
                            <tr key={step.key}>
                                <td>{step.key}. {step.description}</td>
                            </tr>
                        )}
                </tbody>
            </table>
        </div>
    }
}

export default Steps;