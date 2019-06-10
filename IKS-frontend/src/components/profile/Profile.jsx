import React from "react";
import requireAuth from "../../utils/requireAuth";
import ProfileForm from "./ProfileForm";
import ProfileTabs from "./ProfileTabs";
import ProfileHeader from "./ProfileHeader";

class Profile extends React.Component {
  render() {
    const { userProfile } = this.props;
    return (
      <React.Fragment>
        <h1 className="heading1">My profile</h1>
        <div className="content content--stretch">
          <ProfileTabs
            tabs={[
              {
                name: "Personal info",
                link: "/profile"
              },
              {
                name: "Skills",
                link: "/profile/skills"
              },
              {
                name: "Change password",
                link: "/profile/password"
              }
            ]}
          />
          <div className="profile content__scrollable">
            <ProfileHeader />
            <ProfileForm />
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default requireAuth(Profile);
