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
    public class PostTopicManager : IPostTopicService
    {
        IPostTopicDal _postTopicDal;

        public PostTopicManager(IPostTopicDal postTopicDal)
        {
            _postTopicDal = postTopicDal;
        }

        public IResult Add(PostTopic entity)
        {
            _postTopicDal.Add(entity);
            return new SuccessResult(Messages.PostTopic_Added);
        }

        public IResult Delete(PostTopic entity)
        {
            _postTopicDal.Delete(entity);
            return new SuccessResult(Messages.PostTopic_Deleted);
        }

        public IResult Update(PostTopic entity)
        {
            _postTopicDal.Update(entity);
            return new SuccessResult(Messages.PostTopic_Updated);
        }

        public IDataResult<List<PostTopic>> GetAll()
        {
            return new SuccessDataResult<List<PostTopic>>(_postTopicDal.GetAll(), Messages.PostTopics_Listed);
        }

        public IDataResult<PostTopic> GetById(int id)
        {
            return new SuccessDataResult<PostTopic>(_postTopicDal.Get(x => x.Id == id), Messages.PostTopic_Listed);
        }

       
    }
}
