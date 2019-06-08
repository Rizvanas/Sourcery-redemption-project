import { SIGNUP_SUCCESS, SIGNUP_FAILURE } from "../actions/constants";

const INITIAL_STATE = {
  isRegistered: false,
  emailError: null,
  passwordError: null
};

export default function (state = INITIAL_STATE, action) {
  switch (action.type) {
    case SIGNUP_SUCCESS:
      return {
        ...state,
        isRegistered: action.succeeded
      };

    case SIGNUP_FAILURE:
      return {
        ...state,
        isRegistered: false,
        emailError: action.errors.reduce((newArr, err) => {
          if (err.code.includes("Email")) {
            newArr.push(err.description);
          }
          return newArr;
        }, [])[0],
        passwordError: action.errors.reduce((newArr, err) => {
          if (err.code.includes("Password")) {
            newArr.push(err.description);
          }
          return newArr;
        }, [])[0]
      };

    default:
      return state;
  }
}
