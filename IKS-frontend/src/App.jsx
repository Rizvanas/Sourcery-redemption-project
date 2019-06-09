import React from "react";
import { Route } from "react-router-dom";
import Main from "./components/Main";

class App extends React.Component {
  render() {
    return <Route exact path="/" component={Main} />;
  }
}

export default App;
