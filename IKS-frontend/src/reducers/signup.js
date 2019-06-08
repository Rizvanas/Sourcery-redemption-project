import { SIGNUP_SUCCESS, SIGNUP_FAILURE } from "../actions/constants";

const INITIAL_STATE = {
  isRegistered: false,
  message: null
};

export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case SIGNUP_SUCCESS:
      return {
        isRegistered: action.succeeded
      };

    case SIGNUP_FAILURE:
      return {
        isRegistered: false,
        message: action.errors.map(err => err.description)[0]
      };

    default:
      return state;
  }
}
