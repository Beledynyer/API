
using Microsoft.EntityFrameworkCore;
using TheAgoraAPI.Models;

namespace TheAgoraAPI.Repositories
{
    public class ForumPostRepository : IForumPostRepository
    {

        private readonly TheAgoraDbContext dbContext;
        private readonly ILikeRepository likeRepository;
        private readonly ICommentRepository commentRepository;

        public ForumPostRepository(TheAgoraDbContext dbContext, ILikeRepository likeRepository, ICommentRepository commentRepository)
        {
            this.dbContext = dbContext;
            this.likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        public async Task<ForumPost> CreateForumPost(ForumPost post)
        {
            dbContext.ForumPosts.Add(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public  Task<ForumPost> GetForumPostById(int id)
        {
            var posts = dbContext.ForumPosts.Where(x => x.PostId == id).FirstOrDefault();
            return Task.FromResult(posts);
        }

        public async Task<List<ForumPost>> GetForumPosts()
        {
            var posts = await dbContext.ForumPosts.ToListAsync();
            return posts;
        }

        public async Task<int> DeleteForumPost(int id)
        {
            var post = await dbContext.ForumPosts
                .Include(p => p.ForumComments)
                .ThenInclude(fc => fc.Comment) // Include the associated Comment
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return 0;
            }

            // Collect the associated Comment entities
            var commentsToDelete = post.ForumComments.Select(fc => fc.Comment).ToList();

            // Remove associated forum comments first
            dbContext.ForumComments.RemoveRange(post.ForumComments);

            // Then, remove the comments
            dbContext.Comments.RemoveRange(commentsToDelete);

            // First, remove all likes associated with this post
            await likeRepository.RemoveAllLikesForPostAsync(id);

            // Then, delete the forum post
            var rowsAffected = await dbContext.ForumPosts.Where(x => x.PostId == id).ExecuteDeleteAsync();

            return rowsAffected;
        }


    }
}
