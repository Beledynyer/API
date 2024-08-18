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
    }
}
