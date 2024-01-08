using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using BusinessLayer.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Entities;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper) 
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }




        public IDataResult<AccessToken> AccessTokenCreate(User user)
        {
            var userClaims = _userService.GetOperationClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, userClaims.Data);

            return new SuccessDataResult<AccessToken>(accessToken, user.Name);
        }





        public IResult IfUserExist(string email)
        {
            var controlUser = _userService.GetUserByEmail(email);

            if (controlUser.Data != null) 
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }




        [ValidationAspect(typeof(UserLoginDtoValidator))]
        public IDataResult<User> UserLogin(UserLoginDto _userLoginDto)
        {
            var checkUser = _userService.GetUserByEmail(_userLoginDto.Email);

            if (checkUser.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(_userLoginDto.Password,checkUser.Data.PasswordHash,checkUser.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.ErrorPassword);
            }

            return new SuccessDataResult<User>(checkUser.Data, Messages.Successfull_Login);
        }




        [ValidationAspect(typeof(UserRegisterDtoValidator))]
        public IDataResult<User> UserRegister(UserRegisterDto _userRegisterDto, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = _userRegisterDto.Email,
                Name = _userRegisterDto.FirstName,
                Surname = _userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Gender = _userRegisterDto.Gender,
                PhoneNumber = _userRegisterDto.PhoneNo,
                Status = true
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.User_Added);


        }



    }
}
