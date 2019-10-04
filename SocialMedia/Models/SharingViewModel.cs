using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    public class SharingViewModel
    {
        public int Id { get; set; }

        [Required]
        public int SharingCase { get; set; }

        [Required]
        public DateTime SharingDate { get; set; }

        
        public string SharingText { get; set; }

        
        public string SharingImage { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual UserViewModel User { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}