import React from "react";
import { Route, Switch } from "react-router-dom";
import PrivateRoute from "../utils/PrivateRoute";
import Header from "./header/Header";

export default class MainComponent extends React.Component {
  render() {
    return (
      <React.Fragment>
        <main className="main">
          <PrivateRoute path="/header" component={Header} />
        </main>
      </React.Fragment>
    );
  }
}
