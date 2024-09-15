namespace TheAgoraAPI.Interfaces
{
    public interface ILikeRepository
    {
        Task<Like> GetLikeAsync(int userId, int forumPostId);
        Task<bool> AddLikeAsync(int userId, int forumPostId);
        Task<bool> RemoveLikeAsync(int userId, int forumPostId);
        Task<int> GetLikeCountAsync(int forumPostId);
        Task<bool> HasUserLikedPostAsync(int userId, int forumPostId);
        Task RemoveAllLikesForPostAsync(int forumPostId);
    }
}