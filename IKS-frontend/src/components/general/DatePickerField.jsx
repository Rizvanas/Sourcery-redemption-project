import React from "react";
import { KeyboardDatePicker } from "@material-ui/pickers";

export default ({ field, form, ...rest }) => {
  const currentError = form.errors[field.name];
  return (
    <KeyboardDatePicker
      className="form__field"
      autoOk
      disablePast
      variant="inline"
      inputVariant="outlined"
      margin="dense"
      format="yyyy.MM.dd"
      name={field.name}
      value={field.value}
      error={Boolean(currentError)}
      helperText={currentError}
      onChange={nextSLD => form.setFieldValue(field.name, nextSLD, true)}
      {...rest}
    />
  );
};
