namespace TheAgoraAPI.Repositories
{
    public class ForumCommentRepository:IForumCommentRepository
    {
        private readonly TheAgoraDbContext _context;

        public ForumCommentRepository(TheAgoraDbContext context,ICommentRepository commentRepository)
        {
            _context = context;
        }

        public async Task<IEnumerable<ForumComment>> GetCommentsForPostAsync(int postId)
        {
            return await _context.ForumComments
                .Where(fc => fc.PostId == postId)
                .Include(fc => fc.Comment)
                .Include(fc => fc.User)
                .ToListAsync();
        }

        public async Task<ForumComment> AddCommentAsync(ForumComment comment)
        {
            await _context.ForumComments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _context.ForumComments.FindAsync(commentId);
            if (comment == null)
                return false;

            _context.ForumComments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
