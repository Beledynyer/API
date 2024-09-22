namespace TheAgoraAPI.Interfaces
{
    public interface IForumPostRepository
    {
        public Task<List<ForumPost>> GetApprovedForumPosts();
        public Task<List<ForumPost>> GetUnapprovedForumPosts();
        public Task<ForumPost> GetForumPostById(int id);
        public Task<ForumPost> CreateForumPost(ForumPost post);
        public Task<int> DeleteForumPost(int id);
        public Task<ForumPost> ApproveForumPost(int id);
    }
}