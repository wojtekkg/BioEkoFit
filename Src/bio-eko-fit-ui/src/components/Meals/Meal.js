import React from 'react';
import { connect } from 'react-redux';
import { doRemoveMeal } from '../../actions/meals';
import './Meal.css';
import { Button } from 'react-bootstrap';


const Meal = ({ meal, columns, removeMeal }) => {
    const {
        id,
        name,
    } = meal;

    return (
        <div className="meal">
            <span style={{ width: columns.id.width}}>{id}</span>
            <span style={{ width: columns.name.width}}>{name}</span>
            <span style={{ width: columns.actions.width}}><Button variant="danger" onClick={() => removeMeal(id)}>Usuń</Button></span>
        </div>
    );
}

const mapDispatchToProps = dispatch => ({
    removeMeal: id => dispatch(doRemoveMeal(id)),
});

export default connect(
    null, 
    mapDispatchToProps
)(Meal);