import React from "react";
import SvgIcon from "@material-ui/core/SvgIcon";
import SideBack from "../../content/images/illustration.svg";

const container = {
  display: "inline",
  width: "100%",
  paddingBottom: "100%",
  verticalAlign: "middle",
  overflow: "hidden"
};

const content = {
  display: "inline-block",
  position: "relative",
  top: "0",
  left: "0",
  width: "100%",
  height: "100%",
  objectFit: "contain"
};
export default () => {
  return <img src={SideBack} alt="side-back" />;
};
