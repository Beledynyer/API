using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class Bookmark
{
    public int BookmarkId { get; set; }

    public int? UserId { get; set; }

    public int? AnnouncementId { get; set; }

    public DateTime? DateAndTimeOfCreation { get; set; }

    public virtual Announcement? Announcement { get; set; }

    public virtual User? User { get; set; }
}
