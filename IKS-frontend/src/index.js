import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";

const rootElement = document.getElementById("root");
ReactDOM.render(
  <Provider>
    <App />
  </Provider>,
  rootElement
);

registerServiceWorker();
