import React from "react";
import { withStyles } from "@material-ui/core";
import { reduxForm } from "redux-form";
import { connect } from "react-redux";
import { compose } from "redux";
import loginStyles from "../../utils/loginStyles";
import SlackButton from "../general/SlackButton";
import PrimaryButton from "../general/PrimaryButton";
import SignupField from "../general/FormField";
import LoginLink from "../general/FormLink";
import { signup } from "../../actions/index";
import SignupHeader from "./SignupHeader";

const validate = values => {
  const errors = {};
  if (!values.email) {
    errors.email = "Required";
  }
  if (!values.password) {
    errors.password = "Required";
  }
  if (!values.firstName) {
    errors.firstName = "Required";
  }
  if (!values.lastName) {
    errors.lastName = "Required";
  }
  if (values.confirm !== values.password) {
    errors.confirm = "Must match password";
  }
  return errors;
};

class SignupForm extends React.Component {
  onSubmit = formProps => {
    this.props.signup(formProps);
  };

  render() {
    const { handleSubmit, submitting } = this.props;
    const { inputField, smallInputField } = loginStyles;
    return (
      <div className="container main profile__section section">
        <form
          className="form"
          onSubmit={handleSubmit(this.onSubmit)}
          style={{ padding: "50px 0 0 50px" }}
        >
          <SignupHeader />
          <div className="form__row" style={{ width: "432px" }}>
            <SignupField
              type="text"
              name="firstName"
              title="Name"
              placeholder="First Name"
              inputFieldStyle={smallInputField}
              displayErr
            />
            <SignupField
              type="text"
              name="lastName"
              title="Surname"
              placeholder="Last Name"
              inputFieldStyle={smallInputField}
            />
          </div>
          <div className="form__row" style={{ width: "432px" }}>
            <SignupField
              type="email"
              name="email"
              title="Email address"
              placeholder="Enter your email address"
              inputFieldStyle={inputField}
            />
          </div>

          <div className="form__row form__row--last" style={{ width: "432px" }}>
            <SignupField
              type="password"
              name="password"
              title="Password"
              inputFieldStyle={smallInputField}
              placeholder="Enter password"
            />
            <SignupField
              type="password"
              name="confirm"
              title="Confirm password"
              inputFieldStyle={smallInputField}
              placeholder="Enter password"
            />
          </div>

          <div
            className="form__row form__input-wrapper"
            style={{ paddingBottom: "10px" }}
          >
            <PrimaryButton disabled={submitting} text="Sign up" />
          </div>

          <div className="form__row form__row--last form__input-wrapper">
            <SlackButton text="Sign up via Slack" />
          </div>
          <LoginLink
            title="Log in"
            text="Have an account already?"
            to="login"
          />
        </form>
      </div>
    );
  }
}

export default compose(
  connect(
    null,
    { signup }
  ),
  withStyles(loginStyles),
  reduxForm({ form: "signup", destroyOnUnmount: false, validate })
)(SignupForm);
