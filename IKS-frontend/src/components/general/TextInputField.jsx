import React from "react";
import TextField from "@material-ui/core/TextField";

export default ({ field, form, ...rest }) => {
  const currentError = form.errors[field.name];
  return (
    <TextField
      autoComplete="off"
      margin="dense"
      variant="outlined"
      name={field.name}
      value={field.value}
      error={Boolean(currentError)}
      helperText={currentError}
      {...rest}
    />
  );
};
