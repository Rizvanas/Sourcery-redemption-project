using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.General;
using My_IKS.Data.DTO.Requests;
using My_IKS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public ProfileController(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfile>> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
                
            return Ok(_mapper.Map<UserProfile>(user));
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditUserProfile([FromBody] UserProfile userProfileRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            _mapper.Map(userProfileRequest, user);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("skills/{skillId}/edit")]
        public async Task<IActionResult> EditUserSkill(int skillId, [FromBody] SkillUpdateRequest updateRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            _mapper.Map(updateRequest, user.UserSkills.Find(us => us.SkillId == skillId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("skills/{skillId}")]
        public async Task<IActionResult> DeleteUserSkill(int skillId)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            user.UserSkills.Remove(user.UserSkills.Find(us => us.SkillId == skillId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost("skills")]
        public async Task<IActionResult> AddUserSkill([FromBody] SkillAddRequest addRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            user.UserSkills.Add(new UserSkill
            {
                UserId = user.Id,
                User = user,
                Skill = _mapper.Map<Skill>(addRequest),
                SkillLevel = addRequest.SkillLevel
            });

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("goals/{goalId}/edit")]
        public async Task<IActionResult> EditUserGoal(int goalId, GoalUpdateRequest updateRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            _mapper.Map(updateRequest, user.Goals.Find(g => g.GoalId == goalId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("goals/{goalId}")]
        public async Task<IActionResult> DeleteUserGoal(int goalId)
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserId").Value;
                var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

                user.Goals.Remove(user.Goals.Find(g => g.GoalId == goalId));
                await _unitOfWork.CompleteAsync();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("goals")]
        public async Task<IActionResult> AddUserGoal([FromBody] GoalAddRequest addRequest)
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserId").Value;
                var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

                var goal = _mapper.Map<Goal>(addRequest);
                goal.User = user;
                goal.Requests = user.Goals.Count;
                user.Goals.Add(goal);
                await _unitOfWork.CompleteAsync();

            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
