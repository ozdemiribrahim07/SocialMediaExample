using Core.Data;
using Core.Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
        List<UserDto> GetUserDtos(Expression<Func<UserDto,bool>> filter =null);
    }




}
