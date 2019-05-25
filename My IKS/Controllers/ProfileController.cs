using AutoMapper;
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
    [Authorize]
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
        public async Task<ActionResult<UserProfile>> EditUserProfile([FromBody] UserProfile userProfileRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            _mapper.Map(userProfileRequest, user);

            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<UserProfile>(user));
        }

        [HttpPut("skills/{skillId}/edit")]
        public async Task<ActionResult<Object>> EditUserSkill(int skillId, [FromBody] SkillUpdateRequest updateRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            _mapper.Map(updateRequest, user.UserSkills.Find(us => us.SkillId == skillId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("goals/{goalId}/edit")]
        public async Task<ActionResult<Object>> EditUserGoal(int goalId, [FromBody] GoalUpdateRequest updateRequest)
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userRepository.GetUserAsync(Int32.Parse(userId));

            _mapper.Map(updateRequest, user.Goals.Find(g => g.GoalId == goalId));
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
