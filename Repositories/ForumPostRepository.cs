﻿using Microsoft.EntityFrameworkCore;
using TheAgoraAPI.Models;
using TheAgoraAPI.Interfaces;

namespace TheAgoraAPI.Repositories
{
    public class ForumPostRepository : IForumPostRepository
    {
        private readonly TheAgoraDbContext dbContext;
        private readonly ILikeRepository likeRepository;
        private readonly ICommentRepository commentRepository;

        public ForumPostRepository(TheAgoraDbContext dbContext, ILikeRepository likeRepository, ICommentRepository commentRepository)
        {
            this.dbContext = dbContext;
            this.likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        public async Task<ForumPost> CreateForumPost(ForumPost post)
        {
            dbContext.ForumPosts.Add(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public Task<ForumPost> GetForumPostById(int id)
        {
            var posts = dbContext.ForumPosts.Where(x => x.PostId == id).FirstOrDefault();
            return Task.FromResult(posts);
        }

        public async Task<List<ForumPost>> GetApprovedForumPosts()
        {
            var posts = await dbContext.ForumPosts.Where(p => p.IsApproved == true).ToListAsync();
            return posts;
        }

        public async Task<List<ForumPost>> GetUnapprovedForumPosts()
        {
            var posts = await dbContext.ForumPosts.Where(p => p.IsApproved == false).ToListAsync();
            return posts;
        }

        public async Task<int> DeleteForumPost(int id)
        {
            var post = await dbContext.ForumPosts
                .Include(p => p.ForumComments)
                .ThenInclude(fc => fc.Comment)
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return 0;
            }

            var commentsToDelete = post.ForumComments.Select(fc => fc.Comment).ToList();
            dbContext.ForumComments.RemoveRange(post.ForumComments);
            dbContext.Comments.RemoveRange(commentsToDelete);
            await likeRepository.RemoveAllLikesForPostAsync(id);

            var rowsAffected = await dbContext.ForumPosts.Where(x => x.PostId == id).ExecuteDeleteAsync();
            return rowsAffected;
        }

        public async Task<ForumPost> ApproveForumPost(int id)
        {
            var post = await dbContext.ForumPosts.FindAsync(id);
            if (post == null)
            {
                throw new KeyNotFoundException($"Forum post with ID {id} not found.");
            }

            post.IsApproved = true;
            await dbContext.SaveChangesAsync();
            return post;
        }
    }
}