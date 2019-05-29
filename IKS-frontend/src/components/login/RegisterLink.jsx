import React from "react";
import { Link } from "react-router-dom";

export default () => {
  return (
    <div
      className="form__row form__input-wrapper"
      style={{ paddingBottom: "35px" }}
    >
      <p>
        <span className="form__label">Don&#39;t have an account yet?</span>
        <Link
          to="/register"
          className="tabs__link--active"
          style={{ textDecoration: "none" }}
        >
          &nbsp; Create account
        </Link>
      </p>
    </div>
  );
};
