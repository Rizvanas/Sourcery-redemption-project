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
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using My_IKS.Persistance.Configurations;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using My_IKS.Authentication.Extensions;

namespace My_IKS.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationSettings _appSettings;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserRepository userRepository,
            IOptions<ApplicationSettings> appSettings,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
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
            await _signInManager.SignOutAsync();
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, true, true);
            
            if(signInResult.Succeeded)
            {   
                var roles = await _userManager.GetRolesAsync(user);   
                return Ok(new { token = user.GenerateJwtToken(roles, _appSettings.JWTSecret) });
            }
            else
            {
                return BadRequest(new { message = "Email or password is incorrect." });
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }
    }
}
