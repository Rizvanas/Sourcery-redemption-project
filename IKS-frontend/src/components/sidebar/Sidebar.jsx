import React from "react";
import DevbridgeLogo from "./DevbridgeLogo";
import SidebarProfile from "./SidebarProfile";
import SidebarNav from "./SidebarNav";

export default class AdminSidebar extends React.Component {
  render() {
    const { profile } = this.props;
    return (
      <React.Fragment>
        <div className="sidebar">
          <div>
            <DevbridgeLogo />
            <SidebarProfile profile={profile} />
            <SidebarNav profile={profile} />
          </div>
          <p className="sidebar__copyright">© 2019 Devbridge</p>
        </div>
      </React.Fragment>
    );
  }
}
