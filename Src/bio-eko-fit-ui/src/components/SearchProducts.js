import React, { Component } from 'react';
import { connect } from 'react-redux';
import Button from './Button';

const applyQueryState = query => () => ({
  query
});

class SearchProducts extends Component {
  constructor(props) {
    super(props);

    this.state = {
      query: '',
    };

    this.onChange = this.onChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  onSubmit(event) {
    const { query } = this.state;
    if (query) {
      this.props.onFetchProducts(query)

      this.setState(applyQueryState(''));
    }

    event.preventDefault();
  }

  onChange(event) {
    const { value } = event.target;
    this.setState(applyQueryState(value));
  }

  render() {
    return (
      <form onSubmit={this.onSubmit}>
        <input
          type="text"
          value={this.state.query}
          onChange={this.onChange}
        />
        <Button type="submit">
          Search
        </Button>
      </form>
    );
  }
}



export default connect(
  null,
  mapDispatchToProps
)(SearchProducts);