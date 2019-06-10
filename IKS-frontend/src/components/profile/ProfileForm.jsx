import React from "react";
import { reduxForm } from "redux-form";
import disabledCalendar from "../../content/images/calendar-disabled.svg";

class ProfileForm extends React.Component {
  render() {
    return (
      <div className="profile__section section">
        <form className="form">
          <div className="form__row">
            <div className="form__field">
              <label htmlFor="name" className="form__label">
                Name
              </label>
              <input
                className="form__input form__input--disabled"
                type="text"
                id="name"
                value="Carolyn"
                disabled=""
              />
            </div>
            <div className="form__field">
              <label htmlFor="surname" className="form__label">
                Surname
              </label>
              <input
                className="form__input form__input--disabled"
                type="text"
                id="surname"
                value="Simpson"
                disabled=""
              />
            </div>
          </div>
          <div className="form__row">
            <div className="form__field form__field--wide">
              <label htmlFor="email" className="form__label">
                Email address
              </label>
              <input
                type="text"
                id="email"
                className="form__input form__input--disabled"
                value="carolyn.simpson@gmail.com"
                disabled=""
              />
            </div>
          </div>
          <div className="form__row">
            <div className="form__field">
              <label htmlFor="city" className="form__label">
                City
              </label>
              <select
                id="city"
                className="form__input form__input--disabled"
                disabled=""
              >
                <option>Vilnius</option>
                <option>Kaunas</option>
              </select>
            </div>
          </div>
          <div className="form__row form__row--last">
            <div className="form__field">
              <label htmlFor="sld" className="form__label">
                Next SLD
              </label>
              <div className="form__input-suffix-container">
                <input
                  type="text"
                  id="sld"
                  className="form__input form__input--disabled form__input-suffix-field"
                  value="2019.03.21"
                  disabled=""
                />
                <img
                  className="form__input-suffix"
                  src={disabledCalendar}
                  alt="calendar"
                />
              </div>
            </div>
          </div>
        </form>
      </div>
    );
  }
}

export default ProfileForm;
