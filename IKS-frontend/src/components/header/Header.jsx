import React from "react";
import SearchBar from "./SearchBar";
import HeaderNavBar from "./HeaderNavBar";

class Header extends React.Component {
  render() {
    const { profile } = this.props;
    return (
      <div className="container__header">
        <header className="header">
          <SearchBar />
          <HeaderNavBar profile={profile} />
        </header>
      </div>
    );
  }
}

export default Header;
