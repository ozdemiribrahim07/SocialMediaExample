using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Data.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }


        public IResult Add(Post entity)
        {
            _postDal.Add(entity);
            return new SuccessResult(Messages.Post_Added);
        }


        public IResult Delete(Post entity)
        {
            _postDal.Delete(entity);
            return new SuccessResult(Messages.Post_Deleted);
        }


        public IResult Update(Post entity)
        {
            _postDal.Update(entity);
            return new SuccessResult(Messages.Post_Updated);
        }




        public IDataResult<List<Post>> GetAll()
        {
           return new SuccessDataResult<List<Post>>(_postDal.GetAll(),Messages.Posts_Listed);
        }



        public IDataResult<Post> GetById(int id)
        {
            return new SuccessDataResult<Post>(_postDal.Get(x => x.Id == id), Messages.Post_Listed);
        }



    }
}
