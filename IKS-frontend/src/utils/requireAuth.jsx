import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";

export default (ChildComponent, mapStateToProps, actionCreator) => {
  class ComposedComponent extends React.Component {
    componentDidMount() {
      this.props.actionCreator();
    }

    render() {
      const { isAuthenticated, isLoading } = this.props;
      if (isLoading) {
        return <div>Loading...</div>;
      }
      return !isAuthenticated ? (
        <Redirect to="/login" />
      ) : (
        <ChildComponent {...this.props} />
      );
    }
  }

  return connect(
    mapStateToProps,
    { actionCreator }
  )(ComposedComponent);
};
