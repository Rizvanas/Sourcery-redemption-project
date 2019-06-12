import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import Header from "../components/header/Header";
import Sidebar from "../components/sidebar/Sidebar";
import { fetchUserProfile } from "../actions";

export default (ChildComponent, actionCreator) => {
  class ComposedComponent extends React.Component {
    componentDidMount() {
      const { isAuthenticated, isUpdated } = this.props;
      if (!isAuthenticated || isUpdated) {
        this.props.fetchUserProfile();
      }
      if (actionCreator != null) {
        this.props.actionCreator();
      }
    }

    componentDidUpdate() {
      const { isUpdated } = this.props;
      if (isUpdated) {
        this.props.fetchUserProfile();
      }
    }

    render() {
      const {
        isAuthenticated,
        isLoggedIn,
        isLoading,
        userProfile
      } = this.props;

      if (isLoading) {
        return <div>Loading...</div>;
      }
      return !isAuthenticated && !isLoggedIn ? (
        <Redirect to="/login" />
      ) : (
        <React.Fragment>
          <Sidebar profile={userProfile} />
          <div className="container">
            <Header profile={userProfile} />
            <main className="main">
              <ChildComponent {...this.props} />
            </main>
          </div>
        </React.Fragment>
      );
    }
  }

  const mapStateToProps = state => {
    return {
      isAuthenticated: state.auth.isAuthenticated,
      isLoggedIn: state.auth.isLoggedIn,
      isLoading: state.auth.isLoading,
      isUpdated: state.user.isUpdated,
      userProfile: state.user.profile
    };
  };

  return connect(
    mapStateToProps,
    { fetchUserProfile, actionCreator }
  )(ComposedComponent);
};
