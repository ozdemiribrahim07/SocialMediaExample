using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Data.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }



        public IResult Add(User entity)
        {
            var rulesResult = BusinessRules.Run(CheckIfEmailExist(entity.Email));

            if (rulesResult != null)
            {
                return rulesResult;
            }

            _userDal.Add(entity);
            return new SuccessResult(Messages.User_Added);
        }



        public IResult Delete(User entity)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserExist(entity.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedUser = _userDal.Get(x => x.Id == entity.Id);
            _userDal.Delete(deletedUser);
            return new SuccessResult(Messages.User_Deleted);

        }



        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Users_Listed);
        }



        public IDataResult<List<UserDto>> GetAllUsersDto()
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.GetUserDtos(), Messages.Users_Listed);
        }



        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            if (user != null)
            {
                return new SuccessDataResult<User>(Messages.User_Listed);
            }

            return new ErrorDataResult<User>(Messages.UserNotFound);
        }



        public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserExist(user.Id));
            if (rulesResult != null)
            {
                return new ErrorDataResult<List<OperationClaim>>(rulesResult.Message);
            }

            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetOperationClaims(user));
        }



        public DataResult<User> GetUserByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Email == email));
        }




        public IDataResult<UserDto> GetUserDto(int userId)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserDtos(x => x.Id == userId).SingleOrDefault(), Messages.User_Listed);
        }




        public IResult Update(User entity)
        {
            var result = BusinessRules.Run(CheckIfUserExist(entity.Id), CheckIfEmailRight(entity.Email));

            if (result != null)
            {
                return result;
            }

            _userDal.Update(entity);
            return new SuccessResult(Messages.User_Updated);
        }



        public IResult UpdateUserByDto(UserDto userDto)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserExist(userDto.Id), CheckIfEmailRight(userDto.Email));

            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updateUser = _userDal.Get(x => x.Id == userDto.Id && x.Email == userDto.Email);
            if (updateUser == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            updateUser.Name = userDto.FirstName;
            updateUser.Surname = userDto.LastName;
            _userDal.Update(updateUser);
            return new SuccessResult(Messages.User_Updated);
        }


        public IResult DeleteUserById(int userId)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserExist(userId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedUser = _userDal.Get(x => x.Id == userId);
            _userDal.Delete(deletedUser);
            return new SuccessResult(Messages.User_Deleted);
        }






        private IResult CheckIfUserExist(int userId)
        {
            var result = _userDal.GetAll(x => x.Id == userId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult();
        }


        private IResult CheckIfEmailRight(string email)
        {
            var result = BaseCheckIfEmailExists(email);
            if (!result)
            {
                return new ErrorResult(Messages.UserEmailNotRight);
            }
            return new SuccessResult();
        }


        private IResult CheckIfEmailExist(string email)
        {
            var result = BaseCheckIfEmailExists(email);
            if (result)
            {
                return new ErrorResult(Messages.UserEmailAlreadyExist);
            }
            return new SuccessResult();
        }


        private bool BaseCheckIfEmailExists(string email)
        {
            return _userDal.GetAll(x => x.Email == email).Any();
        }

      
    }
}
