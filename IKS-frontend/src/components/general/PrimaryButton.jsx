import React from "react";
import Button from "@material-ui/core/Button";
import { withStyles } from "@material-ui/core/styles";
import loginStyles from "../../utils/loginStyles";

const PrimaryButton = props => {
  const { classes, text, disabled } = props;
  return (
    <Button
      className="button button--primary button--spaced"
      type="submit"
      color="primary"
      disabled={disabled}
      classes={{
        root: classes.buttonRoot,
        label: classes.buttonLabel
      }}
    >
      {text}
    </Button>
  );
};

export default withStyles(loginStyles)(PrimaryButton);
