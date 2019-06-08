import {
  AUTH_SUCCESS,
  AUTH_FAILURE,
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE
} from "../actions/constants";

const INITIAL_STATE = {
  isAuthenticated: false,
  user: {},
  isLoading: true,
  message: null
};
export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case AUTH_SUCCESS:
      return {
        ...state,
        isAuthenticated: true,
        isLoading: false
      };

    case AUTH_FAILURE:
      return {
        ...state,
        isAuthenticated: false,
        message: action.message,
        isLoading: false
      };

    case USER_PROFILE_FETCH_SUCCESS:
      return {
        ...state,
        isAuthenticated: action.user !== null,
        user: action.user,
        isLoading: false
      };
    case USER_PROFILE_FETCH_FAILURE:
      return {
        ...state,
        user: action.user,
        isLoading: false
      };

    default:
      return state;
  }
}
