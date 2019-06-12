import {
  USER_PROFILE_FETCH_SUCCESS,
  USER_PROFILE_FETCH_FAILURE,
  PROFILE_UPDATE_SUCCESS,
  PROFILE_UPDATE_FAILURE
} from "../actions/constants";

const INITIAL_STATE = {
  profile: {},
  isUpdated: false
};

export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case USER_PROFILE_FETCH_SUCCESS:
      return {
        ...state,
        profile: action.user,
        isUpdated: false
      };
    case USER_PROFILE_FETCH_FAILURE:
      return {
        ...state,
        isUpdated: false
      };

    case PROFILE_UPDATE_SUCCESS:
      return {
        ...state,
        isUpdated: true
      };

    case PROFILE_UPDATE_FAILURE:
      return {
        ...state,
        isUpdated: false
      };

    default:
      return state;
  }
}
