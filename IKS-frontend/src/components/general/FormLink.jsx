import React from "react";
import { Link } from "react-router-dom";

export default ({ title, text, to }) => {
  return (
    <div
      className="form__row form__input-wrapper"
      style={{ paddingBottom: "35px" }}
    >
      <p>
        <span className="form__label">{text}</span>
        <Link
          to={to}
          className="tabs__link--active"
          style={{ textDecoration: "none" }}
        >
          &nbsp; {title}
        </Link>
      </p>
    </div>
  );
};
