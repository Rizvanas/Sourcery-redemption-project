using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data.DTO.Requests;
using Microsoft.AspNetCore.Identity;
using My_IKS.Data.Domain;
using My_IKS.Data.Repositories;
using System.Text;
using Microsoft.Extensions.Options;
using My_IKS.Persistance.Configurations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace My_IKS.Controllers
{
    [Route("api/account")]
    [EnableCors("CorsPolicy")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest registerRequest)
        {
            var user = _mapper.Map<User>(registerRequest);

            try
            {
                var result = await _userManager.CreateAsync(user, registerRequest.Password);
                await _userManager.AddToRoleAsync(user, registerRequest.Role);
                return Ok(result);
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {   
            try
            {
                await _signInManager.SignOutAsync();
                var user = await _userManager.FindByEmailAsync(loginRequest.Email);
                var signInResult = await _signInManager.PasswordSignInAsync(user,
                    loginRequest.Password,
                    loginRequest.RememberMe, true);

                if (signInResult.Succeeded)
                {
                    return Ok();
                }

                return Unauthorized(new { message = "Email or password is incorrect." });
            }
            catch
            {
                return Unauthorized(new { message = "Email or password is incorrect." });
            }

        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }
    }
}
