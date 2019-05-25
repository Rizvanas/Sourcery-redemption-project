using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.Requests;
using My_IKS.Data.DTO.Responses;
using My_IKS.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_IKS.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles ="Admin")]
    public class AdminsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminsController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost("requests")]
        public async Task<ActionResult<IEnumerable<UserRequestsResponse>>> GetUserRequests([FromBody] FilterRequest filterRequest)
        {
            var filter = _mapper.Map<Filter>(filterRequest);
            var users = await _userRepository.GetUsersAsync(filter);

            return Ok(_mapper.Map<IEnumerable<UserRequestsResponse>>(users));
        }

        [HttpPut("users/{id}/block")]
        public async Task<ActionResult<NonActiveUserResponse>> BlockUser(int id, [FromBody] FilterRequest filterRequest)
        {
            var user = await _userRepository.GetUserAsync(id);
            user.IsBlocked = true;
            await _unitOfWork.CompleteAsync();

            var filter = _mapper.Map<Filter>(filterRequest);
            var users = await _userRepository.GetUsersAsync(filter);

            return Ok(_mapper.Map<IEnumerable<NonActiveUserResponse>>(users));
        }
    }
}
