import React from "react";
import requireAuth from "../../utils/requireAuth";
import { fetchUserProfile } from "../../actions";

class Header extends React.Component {
  render() {
    return <div>HEADER!</div>;
  }
}

const mapStateToProps = state => {
  return {
    isAuthenticated: state.auth.isAuthenticated,
    isLoading: state.auth.isLoading
  };
};

export default requireAuth(Header, mapStateToProps, fetchUserProfile);
