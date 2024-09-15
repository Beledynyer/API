namespace TheAgoraAPI.Interfaces
{
    public interface IForumCommentRepository
    {
        Task<IEnumerable<ForumComment>> GetCommentsForPostAsync(int postId);
        Task<ForumComment> AddCommentAsync(ForumComment comment);
        Task<bool> DeleteCommentAsync(int commentId);
    }
}
