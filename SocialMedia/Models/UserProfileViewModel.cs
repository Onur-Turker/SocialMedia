using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    public class UserProfileViewModel
    {
        public UserViewModel User { get; set; }
        public List<SharingViewModel> Sharings { get; set; }
    }
}