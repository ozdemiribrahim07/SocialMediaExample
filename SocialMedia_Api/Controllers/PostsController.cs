using BusinessLayer.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Result.Abstract.IResult;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllPosts()
        {
            IDataResult<List<Post>> result = _postService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }



        [HttpPost("Add")]
        public IActionResult Add(Post post)
        {
            IResult result = _postService.Add(post);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }




        [HttpDelete("Delete")]
        public IActionResult Delete(Post post)
        {
            IResult result = _postService.Delete(post);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }



        [HttpPost("Update")]
        public IActionResult Update(Post post)
        {
            IResult result = _postService.Update(post);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }





        [HttpGet("GetById")]
        public IActionResult GetPostById(int id)
        {
           IDataResult<Post> result = _postService.GetById(id);
           return result.IsSuccess ? Ok(result) : BadRequest(result);
        }





    }
}
