using Microsoft.AspNetCore.Mvc;
using TheAgoraAPI.DTOs;
using TheAgoraAPI.Models;
using TheAgoraAPI.Interfaces;

namespace TheAgoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumPostController : ControllerBase
    {
        private readonly IForumPostRepository forumPostRepository;

        public ForumPostController(IForumPostRepository forumPostRepository)
        {
            this.forumPostRepository = forumPostRepository;
        }

        [HttpGet("GetApprovedForumPosts")]
        public async Task<IActionResult> GetApprovedForumPosts()
        {
            try
            {
                var forumPosts = await forumPostRepository.GetApprovedForumPosts();
                return Ok(forumPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUnapprovedForumPosts")]
        public async Task<IActionResult> GetUnapprovedForumPosts()
        {
            try
            {
                var forumPosts = await forumPostRepository.GetUnapprovedForumPosts();
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

        [HttpDelete("DeleteForumPost")]
        public async Task<IActionResult> DeleteForumPost(int id)
        {
            try
            {
                var rowsAffected = await forumPostRepository.DeleteForumPost(id);
                if (rowsAffected > 0)
                {
                    return Ok(new { message = "Forum post, associated comments, and likes deleted successfully." });
                }
                else
                {
                    return NotFound(new { message = "Forum post not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the forum post.", error = ex.Message });
            }
        }

        [HttpGet("GetForumPostById")]
        public async Task<IActionResult> GetForumPostById(int id)
        {
            try
            {
                var post = await forumPostRepository.GetForumPostById(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ApproveForumPost/{id}")]
        public async Task<IActionResult> ApproveForumPost(int id)
        {
            try
            {
                var approvedPost = await forumPostRepository.ApproveForumPost(id);
                return Ok(approvedPost);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while approving the forum post.", error = ex.Message });
            }
        }
    }
}