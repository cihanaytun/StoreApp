using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using storeAPI.Dtos;
using storeAPI.Errors;
using storeAPI.Extensions;
using storeCore.Entities.Identity;
using storeCore.Interfaces;
using storeInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace storeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,ITokenService tokenService,IMapper mapper,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _configuration = configuration;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(User);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }


        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }


        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindByUserClaimsPrincipleWithAddressAsync(User);
            return _mapper.Map<AddressDto>(user.Address);
        }


        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto addressDto)
        {
            var user = await _userManager.FindByUserClaimsPrincipleWithAddressAsync(User);
            user.Address = _mapper.Map<Address>(addressDto);

            var result = await _userManager.UpdateAsync(user);


            if (result.Succeeded) return Ok(_mapper.Map<AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }




        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody]LoginDto loginDto)
        {
            
             var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {    
                return Unauthorized(new ApiResponse(401));   
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName             
            };
            
        }

        
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody]RegisterDto registerDto)
        {
            if (CheckEmailExistAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } });
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}
