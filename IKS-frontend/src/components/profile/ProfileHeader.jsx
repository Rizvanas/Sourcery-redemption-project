import React from "react";
import { Link } from "react-router-dom";
import edit from "../../content/images/edit.svg";

export default () => (
  <div className="profile__section section">
    <Link to="/#" className="edit">
      <img src={edit} alt="edit" />
    </Link>
    <div className="profile__photos">
      <img
        src="https://via.placeholder.com/64x64"
        className="photo"
        alt="profile"
      />
    </div>
  </div>
);
