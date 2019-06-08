import { SIGNUP_SUCCESS, SIGNUP_FAILURE } from "../actions/constants";

const INITIAL_STATE = {
  isRegistered: false
};

export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case SIGNUP_SUCCESS:
      return {
        ...state,
        isRegistered: true
      };

    case SIGNUP_FAILURE:
      return {
        ...state,
        isRegistered: false
      };

    default:
      return state;
  }
}
