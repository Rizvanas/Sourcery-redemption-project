/* eslint-disable import/prefer-default-export */
import axios from "axios";
import {
  AUTH_SUCCESS,
  AUTH_FAILURE,
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE,
  SIGNUP_SUCCESS,
  SIGNUP_FAILURE,
  IS_LOADING
} from "./constants";

export const fetchUserProfile = () => async dispatch => {
  try {
    dispatch({ type: IS_LOADING });
    const response = await axios.get("http://localhost:62727/api/profile", {
      withCredentials: true
    });
    dispatch({ type: USER_PROFILE_FETCH_SUCCESS, user: response.data });
  } catch (error) {
    dispatch({
      type: USER_PROFILE_FETCH_FAILURE,
      message: error.response.data.message
    });
  }
};

export const login = formProps => async dispatch => {
  try {
    dispatch({ type: IS_LOADING });
    await axios.post("http://localhost:62727/api/account/login", formProps, {
      withCredentials: true
    });
    dispatch({ type: AUTH_SUCCESS });
  } catch (error) {
    dispatch({ type: AUTH_FAILURE, message: error.response.data.message });
  }
};

export const signup = formProps => async dispatch => {
  try {
    await axios.post("http://localhost:62727/api/account/register", formProps);
    dispatch({ type: SIGNUP_SUCCESS });
  } catch (error) {
    dispatch({ type: SIGNUP_FAILURE });
  }
};
