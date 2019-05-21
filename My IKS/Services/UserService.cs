using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_IKS.Data.DTO.Responses;
using My_IKS.Persistance.Repositories;
using My_IKS.Data.Repositories;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.Requests;

namespace My_IKS.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly ISkillRepository _skillRepository;

        public UserService(IUserRepository userRepository, IGoalRepository goalRepository, ISkillRepository skillRepository)
        {
            _userRepository = userRepository;
            _goalRepository = goalRepository;
            _skillRepository = skillRepository;
        }
        
        public async Task<UserDetailsResponse> GetUserWithSkills(int userId)
        {
            return GetUserDetails(await _userRepository.Get(userId), _skillRepository.GetUserSkills(userId));
        }

        public async Task<UserDetailsResponse> GetUserWithGoals(int userId)
        {
            return GetUserDetails(await _userRepository.Get(userId), _goalRepository.GetUserGoals(userId));
        }

        public IEnumerable<UserIntroResponse> GetUsersForList(FilterRequest filterRequest)
        {
            return _userRepository.GetUsersAsync().Result.Select(u => new UserIntroResponse
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Location = u.Location,
                SkillTitles = u.UserSkills.Select(us => us.Skill.Title),
                GoalTitles = u.Goals.Select(g => g.Title)
            });
        }

        private UserDetailsResponse GetUserDetails(User user, IEnumerable<UserDetail> details)
        {
            return new UserDetailsResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                JobTitle = user.JobTitle,
                Email = user.Email,
                Details = details
            };
        }
    }
}
