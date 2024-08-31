namespace TheAgoraAPI.Interfaces
{
    public interface IForumPostRepository
    {
        public Task<List<ForumPost>> GetForumPosts();
        public Task<ForumPost> GetForumPostById(int id);
        public Task<ForumPost> CreateForumPost(ForumPost post);
        public Task<int> DeleteForumPost(int id);
    }
}
