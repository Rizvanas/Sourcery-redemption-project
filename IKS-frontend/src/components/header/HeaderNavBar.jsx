import React from "react";
import BellIcon from "./headerIcons/BellIcon";
import CaretDown from "./headerIcons/CaretDownIcon";
import DropdownIconMenu from "./DropdownIconMenu";

class HeaderNavBar extends React.Component {
  renderNavBarDropdown = () => {
    const { profile } = this.props;
    const { firstName, lastName } = profile;
    return (
      <div className="header__profile-nav">
        <img
          className="photo header__profile-photo"
          src="https://via.placeholder.com/36x36"
          alt="profile"
        />
        <div className="header__profile-name">
          {`${firstName} ${lastName}`}
          <DropdownIconMenu
            dropdownListItems={["Option1", "Option2", "Logout"]}
          >
            <CaretDown />
          </DropdownIconMenu>
        </div>
      </div>
    );
  };

  render() {
    return (
      <div className="header__nav">
        <div className="header__notification-nav">
          <DropdownIconMenu
            dropdownListItems={[
              "notification1",
              "notification2",
              "notification3"
            ]}
          >
            <BellIcon />
            <div className="header__notification-count">{3}</div>
          </DropdownIconMenu>
        </div>
        {this.renderNavBarDropdown()}
      </div>
    );
  }
}

export default HeaderNavBar;
