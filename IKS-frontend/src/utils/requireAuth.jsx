import React from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import { fetchUserProfile } from "../actions";

export default ChildComponent => {
  class ComposedComponent extends React.Component {
    componentDidMount() {
      this.props.fetchUserProfile();
    }

    render() {
      const { isAuthenticated } = this.props;
      if (!isAuthenticated) {
        return <Redirect to="/login" />;
      }
      return <ChildComponent {...this.props} />;
    }
  }
  function mapStateToProps(state) {
    return { isAuthenticated: state.auth.isAuthenticated };
  }

  return connect(
    mapStateToProps,
    { fetchUserProfile }
  )(ComposedComponent);
};
