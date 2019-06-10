import React from "react";
import { Route, Switch } from "react-router-dom";
import Profile from "./components/profile/Profile";
import Login from "./components/login/Login";
import Signup from "./components/signup/Signup";
import Mentors from "./components/mentors/Mentors";

class App extends React.Component {
  render() {
    return (
      <Switch>
        <Route exact path="/login" component={Login} />
        <Route exact path="/signup" component={Signup} />
        <Route exact path="/" component={Mentors} />
        <Route exact path="/profile" component={Profile} />
      </Switch>
    );
  }
}

export default App;
