using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data.Repositories;
using My_IKS.Persistance.Repositories;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.Responses;
using My_IKS.Services;
using My_IKS.Data.DTO.Requests;

namespace My_IKS.Controllers
{   
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly UserService _userService;
        public UsersController
        (
            IUserRepository userRepository,
            ISkillRepository skillRepository,
            IGoalRepository goalRepository,
            UserService userService
        )
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _goalRepository = goalRepository;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<User>> GetAll([FromBody] FilterRequest filterRequest)
        {
            return Ok(_userService.GetUsersForList(filterRequest));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> Get(int userId)
        {
            return Ok(await _userRepository.Get(userId));
        }

        [HttpGet("{userId}/skills")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetUserSkills(int userId)
        {
            return Ok(await _userService.GetUserWithSkills(userId));
        }

        [HttpGet("{userId}/goals")]
        public async Task<ActionResult<IEnumerable<Goal>>> GetUserGoals(int userId)
        {
            return Ok(await _userService.GetUserWithGoals(userId));
        }
    }
}
