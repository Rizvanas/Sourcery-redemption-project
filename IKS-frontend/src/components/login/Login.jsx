import React from "react";
import Grid from "@material-ui/core/Grid";
import loginStyles from "../../utils/loginStyles";
import LoginForm from "./LoginForm";

class Login extends React.Component {
  render() {
    const { gridContainer, gridItem } = loginStyles;
    return (
      <Grid container spacing={0} styles={gridContainer}>
        <Grid item xs={12} sm={10} md={6} lg={5} xl={4}>
          <LoginForm />
        </Grid>
        <Grid item xs={false} sm={2} md={6} lg={7} xl={8} style={gridItem} />
      </Grid>
    );
  }
}

export default Login;
