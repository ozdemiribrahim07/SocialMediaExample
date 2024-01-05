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
using System.Xml.Schema;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment entity)
        {
            _commentDal.Add(entity);
            return new SuccessResult(Messages.Comment_Added);
        }

        public IResult Delete(Comment entity)
        {
            _commentDal.Delete(entity);
            return new SuccessResult(Messages.Comment_Deleted);
        }

        public IResult Update(Comment entity)
        {
            _commentDal.Update(entity);
            return new SuccessResult(Messages.Comment_Updated);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(),Messages.Comments_Listed);
        }

        public IDataResult<Comment> GetById(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(x => x.Id == id),Messages.Comment_Listed);
        }

       
    }
}
