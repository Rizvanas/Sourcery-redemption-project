import React from "react";
import { Route, Switch } from "react-router-dom";
import Header from "./header/Header";

class MainComponent extends React.Component {
  render() {
    return (
      <React.Fragment>
        <main className="main">
          <Route path="/header" component={Header} />
        </main>
      </React.Fragment>
    );
  }
}

export default MainComponent;
