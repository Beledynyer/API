using Microsoft.EntityFrameworkCore;
using TheAgoraAPI.Interfaces;
using TheAgoraAPI.Models;

namespace TheAgoraAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TheAgoraDbContext _context;

        public CommentRepository(TheAgoraDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                return false;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Comment?> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }
    }
}