import React from "react";
import Main from "./components/Main";

class App extends React.Component {
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
      <div>
        <Main />
      </div>
    );
  }
}

export default App;
