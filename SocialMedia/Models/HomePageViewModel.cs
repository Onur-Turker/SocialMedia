using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    public class HomePageViewModel
    {
        public List<SharingViewModel> Sharings { get; set; }
        public List<FriendshipRequestViewModel> FSRequests { get; set; }
    }
}