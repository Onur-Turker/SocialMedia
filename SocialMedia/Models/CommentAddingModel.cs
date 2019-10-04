using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    public class CommentAddingModel
    {
       
        public string Text { get; set; }
        public virtual int SharingId { get; set; }
    }
}