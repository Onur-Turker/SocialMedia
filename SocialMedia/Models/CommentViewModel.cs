using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual SharingViewModel Sharing { get; set; }
    }
}