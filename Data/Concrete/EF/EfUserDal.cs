using Core.Data;
using Core.Entities;
using Data.Abstract;
using Data.Concrete.Context;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EF
{
    public class EfUserDal : EFEntityRepo<User, SocialContext>, IUserDal
    {



        public List<OperationClaim> GetOperationClaims(User user)
        {
            using (var context = new SocialContext())
            {
                var result = from operationClaims in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaims.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = userOperationClaim.Id,
                                 RoleName = operationClaims.RoleName
                             };

                return result.ToList();

            }
        }




        public List<UserDto> GetUserDtos(Expression<Func<UserDto, bool>> filter = null)
        {
            using (var context = new SocialContext())
            {
                var result = from user in context.Users
                             select new UserDto
                             {
                                 Id = user.Id,
                                 Email = user.Email,
                                 FirstName = user.Name,
                                 LastName = user.Surname,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }



    }
}
