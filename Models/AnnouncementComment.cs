using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class AnnouncementComment
{
    public int CommentId { get; set; }

    public int? AnnouncementId { get; set; }

    public int? UserId { get; set; }

    public virtual Announcement? Announcement { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual User? User { get; set; }
}
