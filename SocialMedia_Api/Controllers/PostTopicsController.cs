using BusinessLayer.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Result.Abstract.IResult;

namespace SocialMedia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTopicsController : ControllerBase
    {
        private readonly IPostTopicService _postTopicService;

        public PostTopicsController(IPostTopicService postTopicService)
        {
            _postTopicService = postTopicService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllPostTopics()
        {
            IDataResult<List<PostTopic>> result = _postTopicService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(PostTopic postTopic)
        {
            IResult result = _postTopicService.Add(postTopic);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(PostTopic postTopic)
        {
            IResult result = _postTopicService.Delete(postTopic);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetPostTopicById(int id)
        {
            IDataResult<PostTopic> result = _postTopicService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }



        [HttpPut("Update")]
        public IActionResult Update(PostTopic postTopic)
        {
            IResult result = _postTopicService.Update(postTopic);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }



    }
}
