/* eslint-disable import/prefer-default-export */
import backend from "../axios/config";
import {
  AUTH_SUCCESS,
  AUTH_FAILURE,
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE,
  PROFILE_UPDATE_SUCCESS,
  PROFILE_UPDATE_FAILURE,
  SIGNUP_SUCCESS,
  SIGNUP_FAILURE,
  IS_LOADING
} from "./constants";

export const signup = formProps => async dispatch => {
  try {
    const response = await backend.post("/account/register", formProps);
    dispatch({ type: SIGNUP_SUCCESS, succeeded: response.data.succeeded });
  } catch (error) {
    dispatch({ type: SIGNUP_FAILURE, errors: error.response.data.errors });
  }
};

export const login = formProps => async dispatch => {
  try {
    dispatch({ type: IS_LOADING });
    await backend.post("/account/login", formProps);
    dispatch({ type: AUTH_SUCCESS });
  } catch (error) {
    dispatch({ type: AUTH_FAILURE, message: error.response.data.message });
  }
};

export const fetchUserProfile = () => async dispatch => {
  try {
    dispatch({ type: IS_LOADING });
    const response = await backend.get("/profile");
    dispatch({ type: USER_PROFILE_FETCH_SUCCESS, user: response.data });
  } catch (error) {
    dispatch({
      type: USER_PROFILE_FETCH_FAILURE,
      message: error.response.data.message
    });
  }
};

export const updateUserProfile = formProps => async dispatch => {
  try {
    await backend.patch("/profile", formProps);
    dispatch({ type: PROFILE_UPDATE_SUCCESS });
  } catch (error) {
    dispatch({ type: PROFILE_UPDATE_FAILURE });
  }
};
