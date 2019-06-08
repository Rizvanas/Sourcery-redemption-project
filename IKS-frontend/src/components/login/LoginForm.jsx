import React from "react";
import { withStyles } from "@material-ui/core";
import { Link } from "react-router-dom";
import Grid from "@material-ui/core/Grid";
import PropTypes from "prop-types";
import { reduxForm, Field } from "redux-form";
import { connect } from "react-redux";
import { compose } from "redux";
import loginStyles from "../../utils/loginStyles";
import LoginHeader from "./LoginHeader";
import SlackButton from "../general/SlackButton";
import PrimaryButton from "../general/PrimaryButton";
import LoginField from "../general/FormField";
import RegisterLink from "../general/FormLink";
import { login } from "../../actions/index";

const validate = values => {
  const errors = {};
  if (!values.email) {
    errors.email = "Required";
  }
  if (!values.password) {
    errors.password = "Required";
  }
  return errors;
};

class LoginForm extends React.Component {
  onSubmit = formProps => {
    this.props.login(formProps);
  };

  render() {
    const { handleSubmit, submitting } = this.props;
    const { inputField } = loginStyles;
    return (
      <div className="container main profile__section section">
        <form
          className="form"
          onSubmit={handleSubmit(this.onSubmit)}
          style={{ padding: "50px 0 0 50px" }}
        >
          <LoginHeader />
          <div className="form__row" style={{ width: "432px" }}>
            <LoginField
              type="email"
              name="email"
              title="Email address"
              placeholder="Enter your email address"
              inputFieldStyle={inputField}
              displayErr
            />
          </div>
          <div className="form__row" style={{ width: "432px" }}>
            <LoginField
              type="password"
              name="password"
              title="Password"
              inputFieldStyle={inputField}
              placeholder="Enter password"
            />
          </div>
          <div
            className="form__row form__input-wrapper"
            style={{ paddingBottom: "50px", width: "422px" }}
          >
            <Grid container>
              <Grid item xs>
                <Field name="rememberMe" component="input" type="checkbox" />
                <label className="form__label">&nbsp; Remember me</label>
              </Grid>
              <Grid item>
                <Link
                  to="/"
                  className="tabs__link--active"
                  style={{ textDecoration: "none" }}
                >
                  Forgot password?
                </Link>
              </Grid>
            </Grid>
          </div>

          <div
            className="form__row form__input-wrapper"
            style={{ paddingBottom: "10px" }}
          >
            <PrimaryButton disabled={submitting} text="Login" />
          </div>

          <div className="form__row form__row--last form__input-wrapper">
            <SlackButton text="Login via Slack" />
          </div>
          <RegisterLink
            title="Create account"
            text="Don&#39;t have an account yet?"
            to="/signup"
          />
        </form>
      </div>
    );
  }
}

LoginForm.propTypes = {
  classes: PropTypes.object.isRequired
};

export default compose(
  connect(
    null,
    { login }
  ),
  withStyles(loginStyles),
  reduxForm({ form: "login", destroyOnUnmount: false, validate })
)(LoginForm);
