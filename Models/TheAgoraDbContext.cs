using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TheAgoraAPI.Models;

public partial class TheAgoraDbContext : DbContext
{
    public TheAgoraDbContext()
    {

    }

    public TheAgoraDbContext(DbContextOptions<TheAgoraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<AnnouncementComment> AnnouncementComments { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ForumComment> ForumComments { get; set; }

    public virtual DbSet<ForumPost> ForumPosts { get; set; }

    public virtual DbSet<MarketListing> MarketListings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-DRHP09EQ\\SQLEXPRESS;Database=TheAgoraDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Announcement>(entity =>
        //{
        //    entity.HasKey(e => e.AnnouncementId).HasName("PK__Announce__9DE4455444B6AE73");

        //    entity.ToTable("Announcement");

        //    entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");
        //    entity.Property(e => e.AnnouncementType).HasMaxLength(50);
        //    entity.Property(e => e.Campus).HasMaxLength(100);
        //    entity.Property(e => e.DateAndTimeOfCreation)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Date_and_time_of_creation");
        //    entity.Property(e => e.Title).HasMaxLength(100);
        //    entity.Property(e => e.UserId).HasColumnName("UserID");

        //    entity.HasOne(d => d.User).WithMany(p => p.Announcements)
        //        .HasForeignKey(d => d.UserId)
        //        .HasConstraintName("FK__Announcem__UserI__6B24EA82");
        //});
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementId).HasName("PK__Announce__9DE4455444B6AE73");

            entity.ToTable("Announcement");

            entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");
            entity.Property(e => e.AnnouncementType).HasMaxLength(50);
            entity.Property(e => e.Campus).HasMaxLength(100);
            entity.Property(e => e.DateAndTimeOfCreation)
                .HasColumnType("datetime")
                .HasColumnName("Date_and_time_of_creation");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Image).HasColumnType("varbinary(max)"); // Updated to byte[]
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Announcem__UserI__6B24EA82");
        });

        modelBuilder.Entity<AnnouncementComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Announce__C3B4DFAAD0BB8381");

            entity.ToTable("AnnouncementComment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("CommentID");
            entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Announcement).WithMany(p => p.AnnouncementComments)
                .HasForeignKey(d => d.AnnouncementId)
                .HasConstraintName("FK__Announcem__Annou__6EF57B66");

            entity.HasOne(d => d.Comment).WithOne(p => p.AnnouncementComment)
                .HasForeignKey<AnnouncementComment>(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Announcem__Comme__6E01572D");

            entity.HasOne(d => d.User).WithMany(p => p.AnnouncementComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Announcem__UserI__6FE99F9F");
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.BookmarkId).HasName("PK__Bookmark__541A3A91679B2C6E");

            entity.ToTable("Bookmark");

            entity.Property(e => e.BookmarkId).HasColumnName("BookmarkID");
            entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");
            entity.Property(e => e.DateAndTimeOfCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Date_and_time_of_creation");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Announcement).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.AnnouncementId)
                .HasConstraintName("FK__Bookmark__Announ__73BA3083");

            entity.HasOne(d => d.User).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookmark__UserID__72C60C4A");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFAAF5035908");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CommentType).HasMaxLength(50);
            entity.Property(e => e.DateAndTimeOfCreation)
                .HasColumnType("datetime")
                .HasColumnName("Date_and_time_of_creation");
        });

        modelBuilder.Entity<ForumComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__ForumCom__C3B4DFAA0808927F");

            entity.ToTable("ForumComment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("CommentID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Comment).WithOne(p => p.ForumComment)
                .HasForeignKey<ForumComment>(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ForumComm__Comme__66603565");

            entity.HasOne(d => d.Post).WithMany(p => p.ForumComments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__ForumComm__PostI__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.ForumComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ForumComm__UserI__6754599E");
        });

        //modelBuilder.Entity<ForumPost>(entity =>
        //{
        //    entity.HasKey(e => e.PostId).HasName("PK__ForumPos__AA1260389AD44669");

        //    entity.ToTable("ForumPost");

        //    entity.Property(e => e.PostId).HasColumnName("PostID");
        //    entity.Property(e => e.DateAndTimeOfCreation)
        //        .HasColumnType("datetime")
        //        .HasColumnName("Date_and_time_of_creation");
        //    entity.Property(e => e.NumberOfLikes).HasColumnName("Number_of_likes");
        //    entity.Property(e => e.UserId).HasColumnName("UserID");

        //    entity.HasOne(d => d.User).WithMany(p => p.ForumPosts)
        //        .HasForeignKey(d => d.UserId)
        //        .HasConstraintName("FK__ForumPost__UserI__619B8048");
        //});

        modelBuilder.Entity<ForumPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__ForumPos__AA1260389AD44669");

            entity.ToTable("ForumPost");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.DateAndTimeOfCreation)
                .HasColumnType("datetime")
                .HasColumnName("Date_and_time_of_creation");
            entity.Property(e => e.NumberOfLikes).HasColumnName("Number_of_likes");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Title).HasMaxLength(100); // Added Title property
            entity.Property(e => e.Image).HasColumnType("varbinary(max)"); // Updated to byte[]

            entity.HasOne(d => d.User).WithMany(p => p.ForumPosts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ForumPost__UserI__619B8048");
        });

        //modelBuilder.Entity<MarketListing>(entity =>
        //{
        //    entity.HasKey(e => e.ListingId).HasName("PK__MarketLi__BF3EBEF0537BA84B");

        //    entity.ToTable("MarketListing");

        //    entity.Property(e => e.ListingId).HasColumnName("ListingID");
        //    entity.Property(e => e.Category).HasMaxLength(50);
        //    entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        //    entity.Property(e => e.Title).HasMaxLength(100);
        //    entity.Property(e => e.UserId).HasColumnName("UserID");

        //    entity.HasOne(d => d.User).WithMany(p => p.MarketListings)
        //        .HasForeignKey(d => d.UserId)
        //        .HasConstraintName("FK__MarketLis__UserI__5EBF139D");
        //});


        modelBuilder.Entity<MarketListing>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__MarketLi__BF3EBEF0537BA84B");

            entity.ToTable("MarketListing");

            entity.Property(e => e.ListingId).HasColumnName("ListingID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Images).HasColumnType("varbinary(max)"); // Updated to byte[]
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.MarketListings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__MarketLis__UserI__5EBF139D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACD2DE41E7");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("FName");
            entity.Property(e => e.IsStaffMember).HasColumnName("isStaffMember");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("LName");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
