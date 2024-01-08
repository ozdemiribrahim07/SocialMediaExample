using Core.Entities;
using Core.Service;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IServiceRepo<User>
    {
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IDataResult<List<UserDto>> GetAllUsersDto();
        IDataResult<UserDto> GetUserDto(int userId);
        DataResult<User> GetUserByEmail(string email);
        IResult UpdateUserByDto(UserDto userDto);
    }
    
}
