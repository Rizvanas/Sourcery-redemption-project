import React from "react";
import { Route, Switch } from "react-router-dom";
import { MuiPickersUtilsProvider } from "@material-ui/pickers";
import DateFnsUtils from "@date-io/date-fns";
import Profile from "./components/profile/Profile";
import Login from "./components/login/Login";
import Signup from "./components/signup/Signup";
import Mentors from "./components/mentors/Mentors";

class App extends React.Component {
  render() {
    return (
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
        <Switch>
          <Route exact path="/login" component={Login} />
          <Route exact path="/signup" component={Signup} />
          <Route exact path="/" component={Mentors} />
          <Route exact path="/(profile|profile/edit)" component={Profile} />
        </Switch>
      </MuiPickersUtilsProvider>
    );
  }
}

export default App;
