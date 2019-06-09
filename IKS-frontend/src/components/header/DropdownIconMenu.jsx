import React from "react";
import Menu from "@material-ui/core/Menu";
import MenuItem from "@material-ui/core/MenuItem";
import IconButton from "@material-ui/core/IconButton";
import { Fade } from "@material-ui/core";

class DropdownIconMenu extends React.Component {
  state = {
    anchorEl: null
  };

  handleClick = event => {
    this.setState({ anchorEl: event.currentTarget });
  };

  handleClose = () => {
    this.setState({ anchorEl: null });
  };

  renderDropdownList = () => {
    const { dropdownListItems } = this.props;
    return dropdownListItems.map((item, i) => {
      return (
        <MenuItem key={i} onClick={this.handleClose}>
          {item}
        </MenuItem>
      );
    });
  };

  render() {
    const { anchorEl } = this.state;
    const { children } = this.props;
    return (
      <React.Fragment>
        <IconButton
          aria-owns={anchorEl ? "simple-menu" : undefined}
          aria-haspopup="true"
          onClick={this.handleClick}
          aria-label="Primary"
        >
          {children}
        </IconButton>

        <Menu
          id="simple-menu"
          anchorEl={anchorEl}
          open={Boolean(anchorEl)}
          onClose={this.handleClose}
          TransitionComponent={Fade}
        >
          {this.renderDropdownList()}
        </Menu>
      </React.Fragment>
    );
  }
}

export default DropdownIconMenu;
