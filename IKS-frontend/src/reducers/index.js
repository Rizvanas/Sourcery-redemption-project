import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";
import auth from "./auth";
import signup from "./signup";
import user from "./user";

export default combineReducers({ auth, signup, user, form: formReducer });
