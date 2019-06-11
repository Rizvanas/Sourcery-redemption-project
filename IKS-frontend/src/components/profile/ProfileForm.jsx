import React from "react";
import { MenuItem } from "@material-ui/core";
import { Formik, Field, Form } from "formik";
import { connect } from "react-router-dom";
import DatePickerField from "../general/DatePickerField";
import TextInputField from "../general/TextInputField";
import profileSchema from "../../utils/validation/profileSchema";

const cityOptions = [
  { value: "Chicago" },
  { value: "Toronto" },
  { value: "London" },
  { value: "Kaunas" },
  { value: "Vilnius" },
  { value: "Unknown" }
];

class ProfileForm extends React.Component {
  render() {
    const { profile } = this.props;
    return (
      <div className="profile__section section">
        <Formik
          initialValues={{ ...profile, nextSLD: new Date(profile.nextSLD) }}
          onSubmit={values => console.log(values)}
          validationSchema={profileSchema}
        >
          {({ isSubmitting, dirty, handleSubmit, handleChange }) => (
            <Form className="form" onSubmit={handleSubmit}>
              <div className="form__row">
                <Field
                  autoFocus
                  className="form__field"
                  name="firstName"
                  label="Name"
                  placeholder="Enter your name"
                  onChange={handleChange}
                  component={TextInputField}
                />
                <Field
                  className="form__field"
                  name="lastName"
                  label="Surname"
                  placeholder="Enter your surname"
                  onChange={handleChange}
                  component={TextInputField}
                />
              </div>
              <div className="form__row">
                <Field
                  className="form__field form__field--wide"
                  name="email"
                  label="Email address"
                  placeholder="Enter your email address"
                  onChange={handleChange}
                  component={TextInputField}
                />
              </div>
              <div className="form__row">
                <Field
                  select
                  className="form__field"
                  name="location"
                  label="City"
                  onChange={handleChange}
                  component={TextInputField}
                >
                  {cityOptions.map(c => (
                    <MenuItem key={c.value} value={c.value}>
                      {c.value}
                    </MenuItem>
                  ))}
                </Field>
              </div>
              <div className="form__row form__row--last">
                <Field
                  name="nextSLD"
                  label="Next SLD"
                  component={DatePickerField}
                />
              </div>
              <button type="submit" disabled={!isSubmitting && !dirty}>
                Submit test
              </button>
            </Form>
          )}
        </Formik>
      </div>
    );
  }
}

export default ProfileForm;
