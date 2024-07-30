using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class Announcement
{
    public int AnnouncementId { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? AnnouncementType { get; set; }

    public DateTime? DateAndTimeOfCreation { get; set; }

    public string? Campus { get; set; }

    public string? Image { get; set; }

    public string? Tags { get; set; }

    public string? Categories { get; set; }

    public virtual ICollection<AnnouncementComment> AnnouncementComments { get; set; } = new List<AnnouncementComment>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual User? User { get; set; }
}
