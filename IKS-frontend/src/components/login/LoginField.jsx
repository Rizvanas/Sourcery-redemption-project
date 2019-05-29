import React from "react";

class FormField extends React.Component {
  render() {
    const { placeholder, name, title, type } = this.props;
    return (
      <div className="form__row form__field">
        <label htmlFor={name} className="form__label">
          {title}
        </label>
        <input
          component="input"
          placeholder={placeholder}
          className="form__input form__input-wrapper"
          name={name}
          type={type}
          style={{ height: "50px", width: "422px" }}
        />
      </div>
    );
  }
}

export default FormField;
