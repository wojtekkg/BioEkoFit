import React, { Component } from 'react';
import { InputGroup, FormControl, Button } from 'react-bootstrap';



class Steps extends Component{
    constructor(props){
        super(props);

        this.state = {
            stepToAdd: null,
            steps: this.props.steps,
        };
        console.log(this.state.steps);
    }


    render() {
        return <div>
            <InputGroup className="mb-3">
                <FormControl
                    placeholder="Opis kroku"
                    aria-label="Opis kroku"
                    aria-describedby="basic-addon1"
                    onChange={this.onChange}
                />
                <Button type="submit">Dodaj krok</Button>
            </InputGroup>
            <br />
            {this.props.steps.sort((a,b) => a.order - b.order).map(step =>
                <div>{step.order}. {step.description}</div>
            )}
        </div>
    }
}

export default Steps;