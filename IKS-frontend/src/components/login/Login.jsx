import React from "react";
import { Field } from "redux-form";
import { Button } from "@material-ui/core";
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import { Link } from "react-router-dom";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from "prop-types";
import SlackIcon from "./icons/SlackIcon";
import DBLogo from "./icons/DBLogo";
import SideLogo from "../../content/images/illustration.svg";
import loginStyles from "../../utils/loginStyles";

class Login extends React.Component {
  render() {
    const { classes } = this.props;
    return (
      <div style={{ padding: "50px" }}>
        <div className="container__header" style={{ paddingBottom: "61.48px" }}>
          <DBLogo className="logo" />
        </div>
        <h1 className="loginHeading">Log in</h1>
        <div className="form__row">
          <div className="form__field">
            <label htmlFor="email" className="form__label">
              Email address
            </label>
            <input
              component="input"
              placeholder="Enter your email address"
              className="form__input form__input-wrapper"
              name="email"
              type="text"
            />
          </div>
        </div>
        <div className="form__row">
          <div className="form__field">
            <label htmlFor="password" className="form__label">
              Password
            </label>
            <input
              component="input"
              placeholder="Enter password"
              className="form__input form__input-wrapper"
              name="password"
              type="text"
              style={{ height: "50px", width: "422px" }}
            />
          </div>
        </div>
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
          <Button
            className="button button--primary button--spaced"
            type="submit"
            color="primary"
            classes={{
              root: classes.buttonRoot,
              label: classes.buttonLabel
            }}
          >
            Login
          </Button>
        </div>

        <div className="form__row form__row--last form__input-wrapper">
          <Button
            fullWidth
            type="button"
            color="secondary"
            className="button button--primary button--slack button--spaced"
            classes={{
              root: classes.buttonRoot,
              label: classes.buttonLabel
            }}
          >
            <SlackIcon />
            Login via Slack
          </Button>
        </div>
        <div
          className="form__row form__input-wrapper"
          style={{ paddingBottom: "35px" }}
        >
          <p>
            <span className="form__label">Don&#39;t have an account yet?</span>
            <Link
              to="/"
              className="tabs__link--active"
              style={{ textDecoration: "none" }}
            >
              &nbsp; Create account
            </Link>
          </p>
        </div>
      </div>
    );
  }
}

Login.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(loginStyles)(Login);
