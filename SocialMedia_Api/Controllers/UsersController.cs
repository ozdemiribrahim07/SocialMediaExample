using BusinessLayer.Abstract;
using Core.Entities;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using IResult = Core.Utilities.Result.Abstract.IResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<List<User>> result = _userService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest();
        }


        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            IResult result = _userService.Add(user);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }


        [HttpPut("Update")]
        public IActionResult Update(UserDto userDto)
        {
            IResult result = _userService.UpdateUserByDto(userDto);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }



        [HttpDelete("Delete")]
        public IActionResult Delete([FromForm]int id)
        {
            IResult result = _userService.DeleteUserById(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }



        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            IDataResult<UserDto> result = _userService.GetUserDto(id);
            return result.IsSuccess ? Ok(result) : BadRequest();
        }



    }
}
