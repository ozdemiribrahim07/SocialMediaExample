using Core.Data;
using Data.Abstract;
using Data.Concrete.Context;
using Entities.Concrete;

namespace Data.Concrete.EF
{
    public class EfPostDal : EFEntityRepo<Post, SocialContext>, IPostDal
    {


    }
}
