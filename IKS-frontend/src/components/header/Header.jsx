import React from "react";
import { connect } from "react-redux";
import { fetchUserProfile } from "../../actions";

const Header = () => <div>HEADER!</div>;

const mapStateToProps = state => {
  return {
    isAuthenticated: state.auth.isAuthenticated
  };
};

export default connect(
  mapStateToProps,
  { fetchUserProfile }
)(Header);
