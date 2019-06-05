import {
  AUTH_SUCCESS,
  AUTH_FAILURE,
  USER_PROFILE_FETCH_SUCCESS
} from "../actions/constants";

const INITIAL_STATE = {
  isAuthenticated: false,
  user: {}
};
export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case AUTH_SUCCESS:
      return {
        ...state,
        isAuthenticated: true,
        message: null
      };

    case AUTH_FAILURE:
      return {
        ...state,
        isAuthenticated: false,
        message: action.message
      };

    case USER_PROFILE_FETCH_SUCCESS:
      return {
        ...state,
        isAuthenticated: action.user !== null,
        user: action.user
      };
    default:
      return state;
  }
}
