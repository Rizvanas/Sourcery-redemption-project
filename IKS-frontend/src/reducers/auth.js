import { AUTH_SUCCESS, AUTH_FAILURE } from "../actions/constants";

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
    default:
      return state;
  }
}
