import React from "react";
import profileBadgeAdmin from "../../content/images/profile-badge.svg";
import profileBadge from "../../content/images/school.svg";

class SidebarProfile extends React.Component {
  render() {
    const { profile } = this.props;
    const { firstName, lastName } = profile;
    const badgeClass =
      profile.role === "Admin" ? "badge badge--admin" : "badge";
    const badgeIcon =
      profile.role === "Admin" ? profileBadgeAdmin : profileBadge;
    const userRole = profile.role === "Admin" ? "Administrator" : "Student";
    return (
      <div className="me">
        <div className="progress-circle">
          <img
            src="https://via.placeholder.com/64x64"
            className="photo me__photo"
            alt="userPhoto"
          />
        </div>
        <h2 className="heading2 me__name">{`${firstName} ${lastName}`}</h2>

        <div className={badgeClass}>
          <div className="badge__icon">
            <img src={badgeIcon} alt="profileBadge" />
          </div>
          {userRole}
        </div>
      </div>
    );
  }
}

export default SidebarProfile;
