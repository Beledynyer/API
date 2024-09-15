namespace TheAgoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumCommentController : ControllerBase
    {
        private readonly IForumCommentRepository _forumCommentRepository;
        private readonly ICommentRepository _commentRepository;

        public ForumCommentController(IForumCommentRepository forumCommentRepository, ICommentRepository commentRepository)
        {
            _forumCommentRepository = forumCommentRepository;
            _commentRepository = commentRepository;
        }

        [HttpGet("GetComments")]
        public async Task<IActionResult> GetCommentsForPost(int postId)
        {
            var comments = await _forumCommentRepository.GetCommentsForPostAsync(postId);
            return Ok(comments);
        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentDto commentDto)
        {
            var comment = new Comment
            {
                CommentType = "ForumPostComment",
                Content = commentDto.Content,
                DateAndTimeOfCreation = DateTime.UtcNow
            };

            var addedComment = await _commentRepository.AddCommentAsync(comment);

            var forumComment = new ForumComment
            {
                CommentId = addedComment.CommentId,
                UserId = commentDto.UserId,
                PostId = commentDto.PostId,
                Comment = addedComment
            };

            var addedForumComment = await _forumCommentRepository.AddCommentAsync(forumComment);

            return CreatedAtAction(nameof(GetCommentsForPost), new { postId = addedForumComment.PostId }, addedForumComment);
        }

        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var forumCommentDeleted = await _forumCommentRepository.DeleteCommentAsync(commentId);
            if (!forumCommentDeleted)
                return NotFound();

            var commentDeleted = await _commentRepository.DeleteCommentAsync(commentId);
            if (!commentDeleted)
                return StatusCode(500, "Failed to delete the associated Comment record");

            return NoContent();
        }
    }

    public class CommentDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
