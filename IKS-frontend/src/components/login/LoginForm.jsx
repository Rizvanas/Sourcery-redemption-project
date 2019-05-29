import React from "react";
import { withStyles } from "@material-ui/core";
import { Link } from "react-router-dom";
import Grid from "@material-ui/core/Grid";
import PropTypes from "prop-types";
import loginStyles from "../../utils/loginStyles";
import LoginHeader from "./LoginHeader";
import SlackButton from "../general/SlackButton";
import PrimaryButton from "../general/PrimaryButton";
import LoginField from "./LoginField";
import RegisterLink from "./RegisterLink";

class LoginForm extends React.Component {
  render() {
    return (
      <div style={{ padding: "80px 0 0 80px" }}>
        <LoginHeader />
        <LoginField
          type="email"
          name="email"
          title="Email address"
          placeholder="Enter your email address"
        />
        <LoginField
          type="password"
          name="password"
          title="Password"
          placeholder="Enter password"
        />
        <div
          className="form__row form__input-wrapper"
          style={{ paddingBottom: "50px" }}
        >
          <Grid container>
            <Grid item xs>
              <label className="form__label">
                <input type="checkbox" name="remember" />
                &nbsp; Remember me
              </label>
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
          <PrimaryButton text="Login" />
        </div>

        <div className="form__row form__row--last form__input-wrapper">
          <SlackButton />
        </div>
        <RegisterLink />
      </div>
    );
  }
}

LoginForm.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(loginStyles)(LoginForm);
