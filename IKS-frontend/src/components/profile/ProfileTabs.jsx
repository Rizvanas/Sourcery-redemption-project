import React from "react";
import { Link } from "react-router-dom";
import ListItem from "@material-ui/core/ListItem";
import { withStyles } from "@material-ui/core/styles";
import profileTabStyles from "../../utils/profileTabStyles";
import history from "../../history";

class ContentSelectTabs extends React.Component {
  renderTabs() {
    const { classes, tabs } = this.props;
    return (tabs || []).map((tab, index) => {
      return (
        <ListItem
          className="tabs__link tab__link--active"
          classes={{
            root: classes.listItemRoot,
            selected: classes.selected
          }}
          key={index}
          button
          to={tab.link}
          component={Link}
          onClick={() => this.onSelect(tab)}
          selected={tab.link === history.location.pathname}
        >
          {tab.name}
        </ListItem>
      );
    });
  }

  render() {
    return <ul className="tabs content_fixed">{this.renderTabs()}</ul>;
  }
}

export default withStyles(profileTabStyles)(ContentSelectTabs);
