
namespace TheAgoraAPI.Repositories
{
    public class ForumPostRepository : IForumPostRepository
    {

        private readonly TheAgoraDbContext dbContext;

        public ForumPostRepository(TheAgoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ForumPost> CreateForumPost(ForumPost post)
        {
            throw new NotImplementedException();
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
    }
}
