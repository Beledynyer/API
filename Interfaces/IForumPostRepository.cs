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
        public Task<List<ForumPost>> SearchForumPostsByTitle(string searchString);
        public Task<List<ForumPost>> FilterForumPostsByTags(List<string> tags);
        public Task<ForumPost> UpdateNumberOfLikes(int postId, int numberOfLikes);
    }
}