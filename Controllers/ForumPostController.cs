namespace TheAgoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumPostController :ControllerBase
    {
        private readonly IForumPostRepository forumPostRepository;

        public ForumPostController(IForumPostRepository forumPostRepository)
        {
            this.forumPostRepository = forumPostRepository;
        }

        [HttpGet("GetForumPosts")]
        public async Task<IActionResult> GetForumPosts()
        {
            try
            {
                var forumPosts = await forumPostRepository.GetForumPosts();
                return Ok(forumPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateForumPost")]
        public async Task<IActionResult> CreateForumPost([FromBody] ForumPostCreationDto newPostDto)
        {
            try
            {
                // Map the DTO to your ForumPost model
                var newPost = new ForumPost
                {
                    PostId = newPostDto.PostId,
                    UserId = newPostDto.UserId,
                    Title = newPostDto.Title,
                    Content = newPostDto.Content,
                    DateAndTimeOfCreation = newPostDto.DateAndTimeOfCreation,
                    NumberOfLikes = newPostDto.NumberOfLikes,
                    IsApproved = newPostDto.IsApproved,
                    Image = newPostDto.Image,
                    Tags = newPostDto.Tags
                };

                var createdPost = await forumPostRepository.CreateForumPost(newPost);
                return Ok(createdPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
