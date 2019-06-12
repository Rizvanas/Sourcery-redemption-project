import React from "react";
import { Link } from "react-router-dom";
import IconButton from "@material-ui/core/IconButton";
import EditIcon from "../general/icons/EditIcon";
import PlusActiveIcon from "../general/icons/PlusActiveIcon";

export default ({ edit }) => (
  <div className="profile__section section">
    <div className="profile__photos">
      {!edit ? (
        <img
          src="https://via.placeholder.com/64x64"
          className="photo"
          alt="profile"
        />
      ) : (
        <React.Fragment>
          <div className="progress-circle progress-circle--full">
            <img
              src="https://via.placeholder.com/64x64"
              className="photo profile__photo"
              alt="profile"
            />
          </div>
          <div className="profile__add-photo">
            <PlusActiveIcon />
          </div>
        </React.Fragment>
      )}
    </div>
    {!edit ? (
      <IconButton to="/profile/edit" component={Link} className="edit">
        <EditIcon />
      </IconButton>
    ) : null}
  </div>
);
