import React from "react";
import requireAuth from "../../utils/requireAuth";

class Header extends React.Component {
  render() {
    return <div>HEADER!</div>;
  }
}

export default requireAuth(Header);
