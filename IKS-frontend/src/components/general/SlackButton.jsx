import React from "react";
import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from "prop-types";
import loginStyles from "../../utils/loginStyles";
import SlackIcon from "../login/icons/SlackIcon";

const SlackButton = props => {
  const { classes } = props;
  return (
    <Button
      fullWidth
      type="button"
      color="secondary"
      className="button button--primary button--slack button--spaced"
      classes={{
        root: classes.buttonRoot,
        label: classes.buttonLabel
      }}
    >
      <SlackIcon />
      Login via Slack
    </Button>
  );
};

SlackButton.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(loginStyles)(SlackButton);
