import {
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE
} from "../actions/constants";

const INITIAL_STATE = {
  profile: {}
};

export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case USER_PROFILE_FETCH_SUCCESS:
      return {
        ...state,
        profile: action.user
      };
    case USER_PROFILE_FETCH_FAILURE:
      return {
        ...state
      };
    default:
      return state;
  }
}
