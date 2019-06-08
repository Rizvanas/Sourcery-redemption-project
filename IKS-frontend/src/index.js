import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { createStore, applyMiddleware } from "redux";
import reduxThunk from "redux-thunk";
import { Router, Route } from "react-router-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
import reducers from "./reducers";
import history from "./history";
import Login from "./components/login/Login";
import Signup from "./components/signup/Signup";

const rootElement = document.getElementById("root");
const store = createStore(reducers, applyMiddleware(reduxThunk));

ReactDOM.render(
  <Router history={history}>
    <Provider store={store}>
      <Route exact path="/login" component={Login} />
      <Route exact path="/signup" component={Signup} />
      <App />
    </Provider>
  </Router>,
  rootElement
);

registerServiceWorker();
