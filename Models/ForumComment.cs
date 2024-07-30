using System;
using System.Collections.Generic;

namespace TheAgoraAPI.Models;

public partial class ForumComment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual ForumPost? Post { get; set; }

    public virtual User? User { get; set; }
}
