using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsStaffMember { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<AnnouncementComment> AnnouncementComments { get; set; } = new List<AnnouncementComment>();

    public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<ForumComment> ForumComments { get; set; } = new List<ForumComment>();

    public virtual ICollection<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();

    public virtual ICollection<MarketListing> MarketListings { get; set; } = new List<MarketListing>();
}
