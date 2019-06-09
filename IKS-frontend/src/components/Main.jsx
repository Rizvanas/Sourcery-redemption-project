import React from "react";
import { Redirect } from "react-router-dom";
import Header from "./header/Header";
import Sidebar from "./sidebar/Sidebar";
import requireAuth from "../utils/requireAuth";
import { fetchUserProfile } from "../actions";

class MainComponent extends React.Component {
  render() {
    const { isAuthenticated, isLoading, userProfile } = this.props;
    if (isLoading) {
      return <div>Loading...</div>;
    }
    return isAuthenticated ? (
      <React.Fragment>
        <Sidebar profile={userProfile} />
        <div className="container">
          <Header profile={userProfile} />
          <main className="main" />
        </div>
      </React.Fragment>
    ) : (
      <Redirect to="/login" />
    );
  }
}

const mapStateToProps = state => {
  return {
    isAuthenticated: state.auth.isAuthenticated,
    isLoading: state.auth.isLoading,
    userProfile: state.user.profile
  };
};

export default requireAuth(MainComponent, mapStateToProps, fetchUserProfile);
