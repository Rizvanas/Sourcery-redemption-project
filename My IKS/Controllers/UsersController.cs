using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data.Repositories;
using My_IKS.Persistance.Repositories;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.Responses;
using My_IKS.Data.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace My_IKS.Controllers
{   
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public UsersController
        (
            IUserRepository userRepository,
            ISkillRepository skillRepository,
            IGoalRepository goalRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserIntroResponse>>> GetAll([FromBody] FilterRequest filterRequest)
        {
            var filter = _mapper.Map<Filter>(filterRequest);
            var users = await _userRepository.GetUsersAsync(filter);
            var usersResponse = _mapper.Map<IEnumerable<UserIntroResponse>>(users);
            return Ok(usersResponse);
        }

        [HttpGet("{userId}/skills")]
        public async Task<ActionResult<IEnumerable<UserSkillsResponse>>> GetUserSkills(int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            var userWithSkills = _mapper.Map<UserSkillsResponse>(user);
            return Ok(userWithSkills);
        }

        [HttpGet("{userId}/goals")]
        public async Task<ActionResult<IEnumerable<UserGoalsResponse>>> GetUserGoals(int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            var userWithGoals = _mapper.Map<UserGoalsResponse>(user);
            return Ok(userWithGoals);
        }
    }
}
