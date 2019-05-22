using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data.DTO.Requests;
using Microsoft.AspNetCore.Identity;
using My_IKS.Data.Domain;
using My_IKS.Persistance.Repositories;
using My_IKS.Data.Repositories;

namespace My_IKS.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest registerRequest)
        {
            var user = new User
            {
                UserName = registerRequest.UserName,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email
            };

            try
            {
                return Ok(await _userManager.CreateAsync(user, registerRequest.Password));
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
