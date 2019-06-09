import React from "react";
import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import { Link } from "react-router-dom";
import loginStyles from "../../utils/loginStyles";
import SlackIcon from "./icons/SlackIcon";

const SlackButton = props => {
  const { classes, text } = props;
  return (
    <Button
      to="/"
      component={Link}
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
      {text}
    </Button>
  );
};

export default withStyles(loginStyles)(SlackButton);
