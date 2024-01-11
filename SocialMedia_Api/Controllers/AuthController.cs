using BusinessLayer.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var isUserExist = _authService.IfUserExist(userRegisterDto.Email);

            if (!isUserExist.IsSuccess)
            {
                return BadRequest(isUserExist);
            }

            var registerResult = _authService.UserRegister(userRegisterDto, userRegisterDto.Password);
            var result = _authService.AccessTokenCreate(registerResult.Data);

            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto loginDto)
        {
            var userLogin = _authService.UserLogin(loginDto);

            if (!userLogin.IsSuccess)
            {
                return BadRequest(userLogin);
            }

            var result = _authService.AccessTokenCreate(userLogin.Data);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }



    }
}
