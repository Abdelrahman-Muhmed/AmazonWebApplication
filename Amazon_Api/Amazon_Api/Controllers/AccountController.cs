using Amazon_Api.Dtos.AccountModel;
using Amazon_Api.Error;
using Amazon_Api.Extensions;
using Amazon_Core.Model.IdentityModel;
using Amazon_Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Amazon_Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<ApplictionUser> _userManager;
        private readonly SignInManager<ApplictionUser> _signInManager;
        private readonly IAuthServic _authServic;
        private readonly IMapper _mapper;
        public AccountController(UserManager<ApplictionUser> userManager , SignInManager<ApplictionUser> signInManager , IAuthServic authServic , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authServic = authServic;
            _mapper = mapper;
        }
        //Loin 
        [HttpPost("userLogin")]
        public async Task<ActionResult<UserDto>> login(loginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized(new ApiResponse(401));
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.PassWord, false);
            if (!result.Succeeded)
                return Unauthorized(new ApiResponse(401));

            return Ok( new UserDto()
            {
                Email = user.Email,
                Name = user.Name,
                Token = await _authServic.CreateTokenAsync(user , _userManager)
            });
        }

        [HttpPost("userRegister")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            var user = new ApplictionUser()
            {
                Email = register.Email,
                Name = register.Name,
                UserName = register.Email.Split("@")[0],
                PhoneNumber = register.phoneNumber
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                return BadRequest();

            return Ok( new UserDto()
            {
                Name = register.Name,
                Email = register.Email,
                Token = await _authServic.CreateTokenAsync(user, _userManager)
            });
        }


        //For Get Current User By Email 
        [Authorize]
        [HttpGet("getUser")]
        
        public async Task<ActionResult<UserDto>> GetUserName()
        {
            //The User Here Coming From ControllerBase 
            var email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            var user = await _userManager.FindByEmailAsync(email) ;

            return Ok(new UserDto()
            {
                Name = user.Name,
                Email = user.Email,
                Token = await _authServic.CreateTokenAsync(user , _userManager)
            });
        }


        //Get Adress For Current User 
        [Authorize]
        [HttpGet("getAdress")]
        public async Task<ActionResult<AdressDto>> GetAdress()
        {

            var user = await _userManager.findAdressByEmailAsync(User);

            return Ok( _mapper.Map<AdressDto>(user.userAdress));




        }

    }
}
