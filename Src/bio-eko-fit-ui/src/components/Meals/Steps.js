import React, { Component } from 'react';




class Steps extends Component{
    constructor(props){
        super(props);

        this.state = {
            steps: this.props.steps,
        };
        console.log(this.state.steps);
    }


    render() {
        return <div>
            <div><input type='text'></input></div>
            {this.props.steps.sort((a,b) => a.order - b.order).map(step =>
                <div>{step.order}. {step.description}</div>
            )}
        </div>
    }
}

export default Steps;