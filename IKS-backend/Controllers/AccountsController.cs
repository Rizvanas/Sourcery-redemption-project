using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_IKS.Data.DTO.Requests;
using Microsoft.AspNetCore.Identity;
using My_IKS.Data.Domain;
using System.Text;
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
            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if(result.Succeeded)
            {
                await addUserRoleAsync(user);
                return Ok(result);
            }

            return Conflict(new { errors = result.Errors });
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

        private async Task<IdentityResult> addUserRoleAsync(User user)
        {
            if(user.Email.ToLowerInvariant().Contains("admin"))
            {
                return await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                return await _userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
