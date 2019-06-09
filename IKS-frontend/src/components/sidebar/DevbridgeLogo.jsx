import React from "react";
import { Link } from "react-router-dom";
import companyLogo from "../../content/images/logo.svg";

const DevbridgeLogo = () => {
  return (
    <Link to="/" className="logo">
      <div className="logo__wrapper">
        <img src={companyLogo} alt="Devbridge Logo" />
      </div>
    </Link>
  );
};

export default DevbridgeLogo;
