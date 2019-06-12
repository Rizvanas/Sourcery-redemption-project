import React from "react";
import Button from "@material-ui/core/Button";
import history from "../../history";

export default ({ edit, isSubmitting, dirty }) => {
  console.log(`isSubmitting: ${isSubmitting} dirty:${dirty}`);
  return (
    <React.Fragment>
      {edit ? (
        <div className="actions">
          <Button
            type="button"
            className="button button--cancel"
            onClick={() => history.goBack()}
          >
            Cancel
          </Button>
          <Button
            type="submit"
            className="button button--primary"
            disabled={!isSubmitting && !dirty}
            onClick={() => history.goBack()}
          >
            Save
          </Button>
        </div>
      ) : null}
    </React.Fragment>
  );
};
