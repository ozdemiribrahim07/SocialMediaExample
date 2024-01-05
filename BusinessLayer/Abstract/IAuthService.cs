using Core.Entities;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IResult IfUserExist(string email);
        IDataResult<User> UserRegister(UserRegisterDto _userRegisterDto, string password);
        IDataResult<User> UserLogin(UserLoginDto _userLoginDto);
        IDataResult<AccessToken> AccessTokenCreate(User user);
    }
}
