using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? CommentType { get; set; }

    public string? Content { get; set; }

    public DateTime? DateAndTimeOfCreation { get; set; }

    public virtual AnnouncementComment? AnnouncementComment { get; set; }

    public virtual ForumComment? ForumComment { get; set; }
}
