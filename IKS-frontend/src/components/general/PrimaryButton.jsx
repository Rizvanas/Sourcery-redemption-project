import React from "react";
import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import PropTypes from "prop-types";
import loginStyles from "../../utils/loginStyles";

const PrimaryButton = props => {
  const { classes, text } = props;
  return (
    <Button
      className="button button--primary button--spaced"
      type="submit"
      color="primary"
      classes={{
        root: classes.buttonRoot,
        label: classes.buttonLabel
      }}
    >
      {text}
    </Button>
  );
};

PrimaryButton.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(loginStyles)(PrimaryButton);
