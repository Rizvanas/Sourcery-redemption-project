import {
  AUTH_SUCCESS,
  AUTH_FAILURE,
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE
} from "../actions/constants";

const INITIAL_STATE = {
  isAuthenticated: false,
  isLoggedIn: false,
  isLoading: true,
  message: null
};
export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case AUTH_SUCCESS:
      return {
        ...state,
        isLoading: false,
        isLoggedIn: true
      };

    case AUTH_FAILURE:
      return {
        ...state,
        message: action.message,
        isLoading: false
      };

    case USER_PROFILE_FETCH_SUCCESS:
      return {
        ...state,
        isAuthenticated: action.user !== null,
        isLoading: false
      };
    case USER_PROFILE_FETCH_FAILURE:
      return {
        ...state,
        isLoading: false
      };

    default:
      return state;
  }
}
