import React from "react";
import { Route } from "react-router-dom";
import Header from "./header/Header";

class MainComponent extends React.Component {
  render() {
    return (
      <React.Fragment>
        <main className="main">
          <Route exact path="/" component={Header} />
        </main>
      </React.Fragment>
    );
  }
}

export default MainComponent;
