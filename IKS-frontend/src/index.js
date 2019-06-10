import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { createStore, applyMiddleware } from "redux";
import reduxThunk from "redux-thunk";
import { Router } from "react-router-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
import reducers from "./reducers";
import history from "./history";

const rootElement = document.getElementById("root");
const store = createStore(reducers, applyMiddleware(reduxThunk));

ReactDOM.render(
  <Router history={history}>
    <Provider store={store}>
      <App />
    </Provider>
  </Router>,
  rootElement
);

registerServiceWorker();
