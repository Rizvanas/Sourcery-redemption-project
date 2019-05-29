import LoginSideBackground from "../content/images/illustration.svg";

export default {
  buttonRoot: {
    height: "50px",
    width: "422px",
    textTransform: "inherit"
  },
  buttonLabel: {
    fontFamily: "Nunito",
    fontSize: "15px"
  },
  inputRoot: {
    width: "422px",
    height: "50px"
  },
  gridContainer: {
    margin: 0,
    height: "100vh",
    backgroundColor: "#fff"
  },
  gridItem: {
    backgroundColor: "#fff",
    backgroundSize: "cover",
    backgroundPosition: "center",
    backgroundRepeat: "no-repeat",
    backgroundImage: `url(${LoginSideBackground})`
  }
};
