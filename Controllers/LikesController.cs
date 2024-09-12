using Microsoft.AspNetCore.Mvc;
using TheAgoraAPI.Repositories;

namespace TheAgoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;

        public LikesController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpPost("toggle")]
        public async Task<IActionResult> ToggleLike(int userId, int forumPostId)
        {
            var existingLike = await _likeRepository.GetLikeAsync(userId, forumPostId);

            if (existingLike == null)
            {
                // Like doesn't exist, so add it
                await _likeRepository.AddLikeAsync(userId, forumPostId);
                return Ok(new { liked = true });
            }
            else
            {
                // Like exists, so remove it
                await _likeRepository.RemoveLikeAsync(userId, forumPostId);
                return Ok(new { liked = false });
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetLikeCount(int forumPostId)
        {
            var count = await _likeRepository.GetLikeCountAsync(forumPostId);
            return Ok(new { count });
        }
    }
}