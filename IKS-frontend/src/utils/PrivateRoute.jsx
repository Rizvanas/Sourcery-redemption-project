import React, { Component } from "react";
import { Link, Route, Redirect } from "react-router-dom";

const PrivateRoute = ({ component: Component, ...rest }) => {
  <Route {...rest} render={() => {}} />;
};

export default PrivateRoute;
