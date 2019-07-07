import React, { Component } from 'react';
import './Meals.css';
import CommonModal from '../CommonModal';
import { connect } from 'react-redux';
import { Button } from 'react-bootstrap';
import { getMeals } from '../../selectors/meals';
import { doFetchMeals, doAddNewMeal } from '../../actions/meals';
import AddMeal from './AddMeal';
import MealsHeader from './MealsHeader';
import Meal from './Meal';

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

class Meals extends Component{
    constructor(props) {
        super(props);

        this.state = {
            meal:{
                name: '',
            },
            showModal: false,
        };
        this.onSubmit = this.onSubmit.bind(this);
    }

      componentDidMount(prevProps) {
        this.props.onFetchMeals();
    }

    onSubmit(event) {
        this.setState(applyShowModal(true));  
        event.preventDefault();
      }

    applyMealName(name){
        this.setState({
            meal: {
                name
            }
        });
    }

    handleAddMeal(){
        this.props.onAddMeal(this.state.meal);
        this.setState(applyShowModal(false));  
    }

    render() {
        return <div className="meals">
            <div style={{marginLeft: 20}} className="row">
            <form onSubmit={this.onSubmit}>
                <Button type="submit">Stwórz posiłek</Button>
                <CommonModal 
                    show={this.state.showModal} 
                    onHide={() => this.setState(applyShowModal(false))}
                    onHideLabel="Anuluj"
                    onAccept={this.handleAddMeal.bind(this)}
                    onAcceptLabel="Dodaj"
                    header="Tworzenie nowego posiłku"   
                >
                <AddMeal applyMealName={this.applyMealName.bind(this)}/>
                </CommonModal>
            </form>
            </div>
            <hr></hr>
            <MealsHeader columns={COLUMNS}/>
            {(this.props.meals || []).map(meal => 
                <Meal 
                    key={meal.id}
                    meal={meal}
                    columns={COLUMNS}
                />
            )}
        </div>
    }  
}

const mapStateToProps = state => ({
    meals: getMeals(state),
});

const mapDispatchToProps = (dispatch) => ({
    onFetchMeals: () => dispatch(doFetchMeals()),
    onAddMeal: meal => dispatch(doAddNewMeal(meal)),
});

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Meals)
