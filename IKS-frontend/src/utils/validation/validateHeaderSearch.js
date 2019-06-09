export default values => {
  const errors = {};
  if (!values.searchTerm) {
    errors.searchTerm = "Please enter a keyword :)";
  }
  return errors;
};
