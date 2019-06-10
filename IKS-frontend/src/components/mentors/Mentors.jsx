import React from "react";
import requireAuth from "../../utils/requireAuth";

const Mentors = () => <div>Mentors list</div>;

export default requireAuth(Mentors);
