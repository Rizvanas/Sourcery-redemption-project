using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.General;
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

        public ProfileController(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
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
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            _mapper.Map(userProfileRequest, user);

            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<UserProfile>(user));
        }
    }
}
