import React from "react";
import { Router, Route } from "react-router-dom";
import history from "./history";
import Login from "./components/login/Login";
import Main from "./components/Main";

export default class App extends React.Component {
  constructor() {
    super();
    this.state = {
      isAdmin: false
    };

    this.toggleAdmin = this.toggleAdmin.bind(this);
  }

  toggleAdmin() {
    const { isAdmin } = this.state;
    this.setState({ isAdmin: !isAdmin });
  }

  render() {
    return (
      <Router history={history}>
        <React.Fragment>
          <Route exact path="/login" component={Login} />
          <div cla="container">
            <Main />
          </div>
        </React.Fragment>
      </Router>
    );
  }
}
