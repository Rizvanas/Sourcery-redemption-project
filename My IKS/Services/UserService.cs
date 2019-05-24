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
       

        public IEnumerable<UserIntroResponse> GetUsersList(FilterRequest filterRequest)
        {
            return _userRepository.GetUsersAsync(new Filter
            {
                SearchBy = filterRequest.SearchBy,
                Keyword = filterRequest.Keyword,
                SortBy = filterRequest.SortBy,
                Page = filterRequest.Page,
                PageSize = filterRequest.PageSize,
                SortDirection = filterRequest.SortDirection
            }).Result.Select(u => new UserIntroResponse
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Location = u.Location,
                SkillTitles = u.UserSkills.Select(us => us.Skill.Title),
                GoalTitles = u.Goals.Select(g => g.Title)
            });
        }

        public IEnumerable<NonActiveUserResponse> GetNonActiveUsersList(FilterRequest filterRequest)
        {
            return _userRepository.GetUsersAsync(new Filter
            {
                SearchBy = filterRequest.SearchBy,
                Keyword = filterRequest.Keyword,
                SortBy = filterRequest.SortBy,
                Page = filterRequest.Page,
                PageSize = filterRequest.PageSize,
                SortDirection = filterRequest.SortDirection
            }).Result.Select(u => new NonActiveUserResponse
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsActive = u.IsActive,
                IsBLocked = u.IsBlocked,
                LastActiveTime = u.LastActiveTime
            });
        }

    }
}
