using Core.Data;
using Core.Entities;
using Data.Abstract;
using Data.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EF
{
    public class EfUserDal : EFEntityRepo<User,SocialContext>, IUserDal
    {


    }
}
