import React from "react";
import { Link, Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";

const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props =>
      (props.isAuthenticated === true ? (
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      ))
    }
  />
);

const mapStateToProps = state => {
  console.log(state.auth);
  return {
    isAuthenticated: state.auth.isAuthenticated
  };
};

export default connect(
  mapStateToProps,
  {}
)(PrivateRoute);
