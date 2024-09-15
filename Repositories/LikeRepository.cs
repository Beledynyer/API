using Microsoft.EntityFrameworkCore;
using TheAgoraAPI.Models;
using TheAgoraAPI.Interfaces;

namespace TheAgoraAPI.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly TheAgoraDbContext _context;

        public LikeRepository(TheAgoraDbContext context)
        {
            _context = context;
        }

        public async Task<Like> GetLikeAsync(int userId, int forumPostId)
        {
            return await _context.Likes
                .FirstOrDefaultAsync(l => l.UserId == userId && l.ForumPostId == forumPostId);
        }

        public async Task<bool> AddLikeAsync(int userId, int forumPostId)
        {
            var existingLike = await GetLikeAsync(userId, forumPostId);
            if (existingLike != null)
            {
                return false; // Like already exists
            }

            var newLike = new Like
            {
                UserId = userId,
                ForumPostId = forumPostId
            };

            _context.Likes.Add(newLike);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveLikeAsync(int userId, int forumPostId)
        {
            var like = await GetLikeAsync(userId, forumPostId);
            if (like == null)
            {
                return false; // Like doesn't exist
            }

            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetLikeCountAsync(int forumPostId)
        {
            return await _context.Likes.CountAsync(l => l.ForumPostId == forumPostId);
        }

        public async Task<bool> HasUserLikedPostAsync(int userId, int forumPostId)
        {
            return await _context.Likes.AnyAsync(l => l.UserId == userId && l.ForumPostId == forumPostId);
        }

        public async Task RemoveAllLikesForPostAsync(int forumPostId)
        {
            var likesToRemove = await _context.Likes
                .Where(l => l.ForumPostId == forumPostId)
                .ToListAsync();

            _context.Likes.RemoveRange(likesToRemove);
            await _context.SaveChangesAsync();
        }
    }
}