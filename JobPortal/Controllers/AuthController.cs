using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobPortal.Auth;
using JobPortal.Auth.Model;
using JobPortal.Data.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenManager _tokenManager;

        public AuthController(UserManager<User> userManager, IMapper mapper, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByEmailAsync(registerUserDto.Email);
            if (user != null)
                return BadRequest("Email already in use");

            var newUser = new User()
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);
            if (!createUserResult.Succeeded)
                return BadRequest(createUserResult.Errors);

            await _userManager.AddToRoleAsync(newUser, RestUserRoles.Recruiter);

            return CreatedAtAction(nameof(Register), _mapper.Map<UserDto>(newUser));

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return BadRequest("Email or password is invalid");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
                return BadRequest("Email or password is invalid");

            var accessToken = await _tokenManager.CreateAccessTokenAsync(user);

            return Ok(new SuccessfulLoginResponseDto(accessToken));
        }
    }
}
