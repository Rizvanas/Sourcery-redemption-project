import React from "react";
import Grid from "@material-ui/core/Grid";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import loginStyles from "../../utils/loginStyles";
import LoginForm from "./LoginForm";

class Login extends React.Component {
  render() {
    const { isLoggedIn } = this.props;
    const { gridContainer, gridItem } = loginStyles;
    return !isLoggedIn ? (
      <Grid container spacing={0} styles={gridContainer}>
        <Grid item xs={12} sm={10} md={6} lg={5} xl={4}>
          <LoginForm />
        </Grid>
        <Grid item xs={false} sm={2} md={6} lg={7} xl={8} style={gridItem} />
      </Grid>
    ) : (
      <Redirect to="/" />
    );
  }
}

const mapStateToProps = state => {
  return {
    isLoggedIn: state.auth.isLoggedIn
  };
};

export default connect(mapStateToProps)(Login);
