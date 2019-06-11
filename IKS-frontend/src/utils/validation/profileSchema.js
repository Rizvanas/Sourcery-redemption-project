import * as yup from "yup";

export default yup.object().shape({
  firstName: yup.string().required("Name is Required"),
  lastName: yup.string().required("Surname is Required"),
  location: yup.string().required("City is Required"),
  email: yup
    .string()
    .email("Please Enter a valid email")
    .required("Email Address is required")
});
