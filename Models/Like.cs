using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheAgoraAPI.Models
{
    public partial class Like
    {
        public int LikeId { get; set; }

        public int? UserId { get; set; }

        [Column("PostID")]
        public int? ForumPostId { get; set; }

        public virtual ForumPost? ForumPost { get; set; }

        public virtual User? User { get; set; }
    }
}
