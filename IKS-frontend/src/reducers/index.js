import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";
import auth from "./auth";
import signup from "./signup";

export default combineReducers({ auth, signup, form: formReducer });
