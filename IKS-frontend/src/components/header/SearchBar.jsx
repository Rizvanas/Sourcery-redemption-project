import React from "react";
import { Field, reduxForm } from "redux-form";
import { connect } from "react-redux";
import searchIcon from "../../content/images/search.svg";
import validate from "../../utils/validation/validateHeaderSearch";

class SearchBar extends React.Component {
  onSubmit = formValues => {
    console.log(formValues);
  };

  renderInput = ({ input }) => {
    return (
      <input
        {...input}
        placeholder="Search by a keyword..."
        type="text"
        className="searchbar__input"
      />
    );
  };

  render() {
    const { handleSubmit } = this.props;
    return (
      <form className="searchbar" onSubmit={handleSubmit(this.onSubmit)}>
        <img src={searchIcon} alt="search icon" />
        <Field name="searchTerm" component={this.renderInput} />
      </form>
    );
  }
}

export default connect(null)(
  reduxForm({ form: "searchbar", validate })(SearchBar)
);
