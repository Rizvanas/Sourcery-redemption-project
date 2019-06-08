import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import Grid from "@material-ui/core/Grid";
import loginStyles from "../../utils/loginStyles";
import SignupForm from "./SignupForm";

class Register extends React.Component {
  render() {
    const { isAuthenticated } = this.props;
    const { gridContainer, gridItem } = loginStyles;
    return !isAuthenticated ? (
      <Grid container spacing={0} styles={gridContainer}>
        <Grid item xs={12} sm={10} md={6} lg={5} xl={4}>
          <SignupForm />
        </Grid>
        <Grid item xs={false} sm={2} md={6} lg={7} xl={8} style={gridItem} />
      </Grid>
    ) : (
      <Redirect to="/login" />
    );
  }
}
const mapStateToProps = state => {
  return {
    isRegistered: state.signup.isRegistered
  };
};

export default connect(mapStateToProps)(Register);
