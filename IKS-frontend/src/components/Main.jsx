import React from "react";
import { Route, Switch } from "react-router-dom";
import Login from "./login/Login";

export default class MainComponent extends React.Component {
  render() {
    return (
      <main className="main">
        <Switch />
      </main>
    );
  }
}
