import React from "react";
import { withStyles } from "@material-ui/core/styles";
import { Link } from "react-router-dom";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import HelpIcon from "./sidebarIcons/HelpIcon";
import ProfileIcon from "./sidebarIcons/ProfileIcon";
import ListIcon from "./sidebarIcons/ListIcon";
import AdminIcon from "./sidebarIcons/AdminIcon";
import history from "../../history";

const sidebarStyles = {
  listItemRoot: {
    "&$selected": {
      backgroundColor: "#f3f7fd",
      color: "#404dfa",
      borderLeft: "3px solid #404dfa",
      "&:hover, &:focus, &:active": {
        backgroundColor: "#f3f7fd",
        color: "#404dfa",
        borderLeft: "3px solid #404dfa"
      }
    },
    "&:hover, &:focus, &:active": {
      backgroundColor: "#f3f7fd",
      color: "#404dfa",
      borderLeft: "3px solid #404dfa",
      fill: "#404dfa"
    }
  },
  selected: {}
};

class SidebarNav extends React.Component {
  render() {
    const { profile, classes } = this.props;
    return (
      <nav>
        <List className="nav">
          {[
            {
              Title: "My profile",
              Link: "/profile",
              Icon: <ProfileIcon />
            },
            { Title: "Find a mentor", Link: "/", Icon: <ListIcon /> },
            profile.role === "Admin"
              ? {
                  Title: "Administration",
                  Link: "/admin",
                  Icon: <AdminIcon />
                }
              : null,
            { Title: "Help", Link: "/help", Icon: <HelpIcon /> }
          ].map((item, index) =>
            (item !== null ? (
              <ListItem
                classes={{
                  root: classes.listItemRoot,
                  selected: classes.selected
                }}
                to={item.Link}
                className="nav-link"
                button
                key={index}
                component={Link}
                selected={item.Link === history.location.pathname}
              >
                <div className="nav-link__icon">{item.Icon}</div>
                {item.Title}
              </ListItem>
            ) : null)
          )}
        </List>
      </nav>
    );
  }
}

export default withStyles(sidebarStyles)(SidebarNav);
