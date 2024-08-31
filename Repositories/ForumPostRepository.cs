
using TheAgoraAPI.Models;

namespace TheAgoraAPI.Repositories
{
    public class ForumPostRepository : IForumPostRepository
    {

        private readonly TheAgoraDbContext dbContext;

        public ForumPostRepository(TheAgoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ForumPost> CreateForumPost(ForumPost post)
        {
            dbContext.ForumPosts.Add(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public Task<ForumPost> GetForumPostById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ForumPost>> GetForumPosts()
        {
            var posts = await dbContext.ForumPosts.ToListAsync();
            return posts;
        }

        public async Task<int>  DeleteForumPost(int id)
        {
            var rowsAffected = await dbContext.ForumPosts.Where(x => x.PostId == id).ExecuteDeleteAsync();
            return rowsAffected;
        }
    }
}
