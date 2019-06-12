import React from "react";
import { MenuItem } from "@material-ui/core";
import { Formik, Field, Form } from "formik";
import { connect } from "react-redux";
import DatePickerField from "../general/DatePickerField";
import TextInputField from "../general/TextInputField";
import profileSchema from "../../utils/validation/profileSchema";
import { updateUserProfile, fetchUserProfile } from "../../actions";
import FormButtons from "../general/FormButtons";

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
    const { profile, edit, updateUserProfile } = this.props;
    return (
      <div className="profile__section section">
        <Formik
          initialValues={{ ...profile, nextSLD: new Date(profile.nextSLD) }}
          onSubmit={formProps => updateUserProfile(formProps)}
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
                  disabled={!edit}
                  onChange={handleChange}
                  component={TextInputField}
                />
                <Field
                  className="form__field"
                  name="lastName"
                  label="Surname"
                  placeholder="Enter your surname"
                  disabled={!edit}
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
                  disabled={!edit}
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
                  disabled={!edit}
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
                  disabled={!edit}
                  component={DatePickerField}
                />
              </div>
              <FormButtons
                edit={edit}
                isSubmitting={isSubmitting}
                dirty={dirty}
              />
            </Form>
          )}
        </Formik>
      </div>
    );
  }
}

const mapStateToProps = state => {
  return {
    isUpdated: state.user.isUpdated,
    userProfile: state.user.profile
  };
};

export default connect(
  mapStateToProps,
  { updateUserProfile }
)(ProfileForm);
