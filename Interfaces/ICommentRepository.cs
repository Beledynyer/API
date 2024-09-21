namespace TheAgoraAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> AddCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int commentId);
        Task<Comment?> GetCommentByIdAsync(int commentId);
    }
}