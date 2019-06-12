using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.General;
using My_IKS.Data.DTO.Requests;
using My_IKS.Data.Repositories;
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace My_IKS.Controllers
{
    [Authorize]
    [Route("api/profile")]
    [EnableCors("CorsPolicy")]
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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            var userProfile = _mapper.Map<UserProfile>(user);
            userProfile.Role = role;
            return Ok(userProfile);
        }

        [HttpPatch]
        public async Task<IActionResult> EditUserProfile([FromBody] UserProfile userProfileRequest)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            _mapper.Map(userProfileRequest, user);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("skills/{skillId}/edit")]
        public async Task<IActionResult> EditUserSkill(int skillId, [FromBody] SkillUpdateRequest updateRequest)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            _mapper.Map(updateRequest, user.UserSkills.Find(us => us.SkillId == skillId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("skills/{skillId}")]
        public async Task<IActionResult> DeleteUserSkill(int skillId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            user.UserSkills.Remove(user.UserSkills.Find(us => us.SkillId == skillId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPost("skills")]
        public async Task<IActionResult> AddUserSkill([FromBody] SkillAddRequest addRequest)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
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
            var userId = _userManager.GetUserId(HttpContext.User);
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
                var userId = _userManager.GetUserId(HttpContext.User);
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
                var userId = _userManager.GetUserId(HttpContext.User);
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
