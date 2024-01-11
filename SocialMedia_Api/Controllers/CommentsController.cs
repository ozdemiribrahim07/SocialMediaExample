using BusinessLayer.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Result.Abstract.IResult;
using System.Runtime.CompilerServices;

namespace SocialMedia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllComments()
        {
            IDataResult<List<Comment>> result = _commentService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Comment comment)
        {
            IResult result = _commentService.Add(comment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(Comment comment)
        {
            IResult result = _commentService.Update(comment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(Comment comment)
        {
            IResult result = _commentService.Delete(comment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetCommentById(int id)
        {
            IDataResult<Comment> result = _commentService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }






    }


}
