import React from "react";
import requireAuth from "../../utils/requireAuth";
import ProfileForm from "./ProfileForm";
import ProfileTabs from "./ProfileTabs";
import ProfileHeader from "./ProfileHeader";

class Profile extends React.Component {
  render() {
    const { history, userProfile } = this.props;
    console.log(history);
    const edit = history.location.pathname.includes("edit");
    console.log(edit);
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
            <ProfileHeader edit={edit} />
            <ProfileForm profile={userProfile} edit={edit} />
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default requireAuth(Profile);
