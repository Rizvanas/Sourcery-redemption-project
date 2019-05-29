import React from "react";
import { Router, Route } from "react-router-dom";
import Grid from "@material-ui/core/Grid";
import history from "./history";
import Login from "./components/login/Login";
import LoginSideBackground from "./content/images/illustration.svg";

export default class App extends React.Component {
  constructor() {
    super();
    this.state = {
      isAdmin: false
    };

    this.toggleAdmin = this.toggleAdmin.bind(this);
  }

  toggleAdmin() {
    const { isAdmin } = this.state;
    this.setState({ isAdmin: !isAdmin });
  }

  render() {
    return (
      <Router history={history}>
        <React.Fragment>
          {/* <button
            type="button"
            style={{ position: "absolute", fontSize: "10px" }}
            href=" "
            className=""
            onClick={this.toggleAdmin}
          >
            Toggle
          </button> */}
          {/* <Sidebar isAdmin={isAdmin} /> */}
          <Grid
            container
            spacing={0}
            style={{
              margin: 0,
              height: "100vh"
            }}
          >
            <Grid item xs={12} sm={10} md={6} lg={5} xl={4}>
              <main className="container main content content--stretch section">
                <Route exact path="/login" component={Login} />
              </main>
            </Grid>
            <Grid
              item
              xs={false}
              sm={2}
              md={6}
              lg={7}
              xl={8}
              style={{
                backgroundSize: "cover",
                backgroundPosition: "center",
                backgroundRepeat: "no-repeat",
                backgroundImage: `url(${LoginSideBackground})`
              }}
            />
          </Grid>

          {/* <div className="container">
            <Header />
            <Main history={history} isAdmin={isAdmin} />
          </div> */}
        </React.Fragment>
      </Router>
    );
  }
}
