/* eslint-disable import/prefer-default-export */
import axios from "axios";
import {
  AUTH_SUCCESS,
  AUTH_FAILURE,
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE
} from "./constants";

export const fetchUserProfile = () => async dispatch => {
  try {
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
    await axios.post("http://localhost:62727/api/account/login", formProps, {
      withCredentials: true
    });
    dispatch({ type: AUTH_SUCCESS });
  } catch (error) {
    dispatch({ type: AUTH_FAILURE, message: error.response.data.message });
  }
};
