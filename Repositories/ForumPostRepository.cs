
using TheAgoraAPI.Models;

namespace TheAgoraAPI.Repositories
{
    public class ForumPostRepository : IForumPostRepository
    {

        private readonly TheAgoraDbContext dbContext;
        private readonly ILikeRepository likeRepository;

        public ForumPostRepository(TheAgoraDbContext dbContext,ILikeRepository likeRepository)
        {
            this.dbContext = dbContext;
            this.likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
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
            // First, remove all likes associated with this post
            await likeRepository.RemoveAllLikesForPostAsync(id);

            // Then, delete the forum post
            var rowsAffected = await dbContext.ForumPosts.Where(x => x.PostId == id).ExecuteDeleteAsync();
            return rowsAffected;
        }
    }
}
